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
        public  Task<List<CartItem>> GetAllIncludingKitAsync(int page, int pageSize, int kitId);

        Task<CartItem> GetById(int id);

        Task Add(CartItem cartItem);

        Task Update(int id, CartItem cartItem);

        Task Delete(int id);

      

    }
}
