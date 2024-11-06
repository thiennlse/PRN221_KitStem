using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory;
using Reposiory.Interface;
using Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        private readonly KitStemDBContext _context;

        public CartItemRepository(KitStemDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int kitId)
        {
            var cartItem = await _context.CartItems.FindAsync(kitId);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _context.CartItems.ToListAsync();
        }

        public async Task<List<CartItem>> GetAllIncludingKitAsync(int page, int pageSize, int kitId)
        {
            var query = _context.CartItems
                .Include(ci => ci.Kit) // Include the related Kit entity
                .Where(ci => ci.KitId == kitId); // Filter by kitId

            return await query.Skip((page - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();
        }






        public async Task<CartItem?> GetByIdAsync(int kitId)
        {
            return await _context.CartItems
                .Include(ci => ci.Kit) // Include the related Kit entity
                .FirstOrDefaultAsync(ci => ci.KitId == kitId);
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
