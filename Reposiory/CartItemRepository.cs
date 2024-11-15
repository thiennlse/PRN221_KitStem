using BusinessObject.Models;
using BusinessObject.RequestModel;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly KitStemDBContext _context;

        public CartItemRepository(KitStemDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddCartItem(int userId, int kitId, int quantity)
        {
            var kit = await _context.KitStems.FindAsync(kitId);

            if (kit == null)
            {
                throw new InvalidOperationException("Kit not found.");
            }

            if (quantity > kit.quantity)
            {
                throw new InvalidOperationException("Quantity exceeds available stock.");
            }

            var existingCartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.KitId == kitId);

            if (existingCartItem != null)
            {
                int newQuantity = (int)(existingCartItem.Quantity + quantity);
                if (newQuantity > kit.quantity)
                {
                    throw new InvalidOperationException("Total quantity exceeds available stock.");
                }
                existingCartItem.Quantity = newQuantity;
            }
            else
            {
                var cartItem = new CartItem
                {
                    UserId = userId,
                    KitId = kitId,
                    Quantity = quantity
                };

                await _context.CartItems.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetCartItemsByUserId(int userId)
        {
            return await _context.CartItems
                .Where(ci => ci.UserId == userId)
                .Include(ci => ci.Kit) 
                .ToListAsync();
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            _context.Entry(cartItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
