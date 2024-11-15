using BusinessObject.Models;
using BusinessObject.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Reposiory.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetAll(int page, int pageSize, string? searchTerm);
        Task<Order> CreateOrder(List<CartItem> cartItems);
        Task UpdateAsync(Order order);
        Task<List<Order>> GetOrderByOrderId(int userId);
    }
}
