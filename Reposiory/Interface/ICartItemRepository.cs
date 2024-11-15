using BusinessObject.Models;
using BusinessObject.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        Task AddCartItem(int userId, int kitId , int quantity);
        Task UpdateAsync(CartItem cart);
        Task<List<CartItem>> GetCartItemsByUserId(int userId);
    }
}
