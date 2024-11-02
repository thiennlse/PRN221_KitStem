using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICartItemService
    {
        Task<List<CartItem>> GetAllAsync(int page, int pageSize, string? searchTerm);

        Task<CartItem> GetById(int id);

        Task Add(CartItem cartItem);

        Task Update(int id, CartItem cartItem);

        Task Delete(int id);

      

    }
}
