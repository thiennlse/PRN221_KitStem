using BusinessObject.Models;
using BusinessObject.RequestModel;
using Reposiory;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public Task AddCartItem(int userId, int kitId, int quantity)
        {
            return _cartItemRepository.AddCartItem(userId, kitId, quantity);
        }

        public Task<List<CartItem>> GetCartItemsByUserId(int userId)
        {
            return _cartItemRepository.GetCartItemsByUserId(userId);
        }

        public Task UpdateAsync(CartItem cart)
        {
            return _cartItemRepository.UpdateAsync(cart);
        }

        public async Task<CartItem> GetById(int id)
        {
            return await _cartItemRepository.GetById(id);
        }

        public async Task DeleteById(int id)
        {
            await _cartItemRepository.Remove(id);
        }


    }
}
