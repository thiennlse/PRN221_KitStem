using BusinessObject.Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new CartItem to the repository.
        /// </summary>
        public async Task Add(CartItem cartItem)
        {
            await _repository.AddAsync(cartItem);
        }

        /// <summary>
        /// Deletes a CartItem by its ID.
        /// </summary>
        public async Task Delete(int kitId)
        {
            await _repository.RemoveAsync(kitId);
        }

        /// <summary>
        /// Retrieves a paginated list of CartItems with optional search functionality.
        /// </summary>
        public async Task<List<CartItem>> GetAllIncludingKitAsync(int page, int pageSize, int kitId)
        {
            // Call the repository method to fetch cart items including the kit based on the given parameters
            return await _repository.GetAllIncludingKitAsync(page, pageSize,kitId);
        }



        /// <summary>
        /// Retrieves a specific CartItem by its ID.
        /// </summary>
        public async Task<CartItem> GetById(int kitId)
        {
            return await _repository.GetByIdAsync(kitId);
        }

        /// <summary>
        /// Updates an existing CartItem.
        /// </summary>
        public async Task Update(int kitId, CartItem cartItem)
        {
           

            await _repository.UpdateAsync(cartItem);
        }
    }
}
