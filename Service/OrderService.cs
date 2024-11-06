using BusinessObject.Models;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class OrderService : IOrderService
    {
        
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return _orderRepository.GetAllOrdersAsync();
        }

        public Task<Order> GetOrderByIdAsync(int userId)
        {
            return _orderRepository.GetOrderByIdAsync(userId);
        }

        public Task CreateOrderAsync(Order order)
        {
            return _orderRepository.CreateOrderAsync(order);
        }

        public Task UpdateOrderAsync(Order order)
        {
            return _orderRepository.UpdateOrderAsync(order);
        }

        public Task DeleteOrderAsync(int userId)
        {
            return _orderRepository.DeleteOrderAsync(userId);
        }
    }

}

