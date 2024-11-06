using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly KitStemDBContext _context;

        public OrderRepository(KitStemDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.KitOrders).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int userId)
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.KitOrders)
                .FirstOrDefaultAsync(o => o.UserId == userId);
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int userId)
        {
            var order = await GetOrderByIdAsync(userId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
