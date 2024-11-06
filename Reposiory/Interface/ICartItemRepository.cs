﻿using BusinessObject.Models;
using Reposiory.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICartItemRepository:IBaseRepository<CartItem>
    {
        Task AddAsync(CartItem cartItem);
        Task RemoveAsync(int  kitId);
        Task<List<CartItem>> GetAllAsync();
        public Task<List<CartItem>> GetAllIncludingKitAsync(int page, int pageSize, int kitId);
        Task<CartItem?> GetByIdAsync(int kitId);
        Task UpdateAsync(CartItem cartItem);
    }
}