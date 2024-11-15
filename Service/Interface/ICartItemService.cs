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
        Task AddCartItem(int userId, int kitId, int quantity);
        Task UpdateAsync(CartItem cart);
        Task<List<CartItem>> GetCartItemsByUserId(int userId);
        Task<CartItem> GetById(int id);
        Task DeleteById(int id);

    }

}
