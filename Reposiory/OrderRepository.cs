using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reposiory.Interface;
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
        public OrderRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Order> CreateOrder(List<CartItem> cartItems)
        {
            if (cartItems == null || !cartItems.Any())
                throw new ArgumentException("Cart cannot be empty.");

            var newOrder = new Order
            {
                UserId = cartItems.First().UserId, 
                StaffId = null, 
                CreateDay = DateTime.Now,
                OrderDay = DateTime.Now, 
                TotalPrice = 0, 
                Status = 1, 
                KitOrders = new List<KitOrder>()
            };

            double totalPrice = 0;

            foreach (var cartItem in cartItems)
            {
                if (cartItem.Quantity > cartItem.Kit.quantity)
                    throw new InvalidOperationException($"Insufficient stock for kit ID {cartItem.KitId}");

                var kitOrder = new KitOrder
                {
                    OrderId = newOrder.Id,
                    KitId = cartItem.KitId,
                    Quantity = cartItem.Quantity,
                    Price = (double?)(cartItem.Kit.price * cartItem.Quantity)
                };

                newOrder.KitOrders.Add(kitOrder);

                totalPrice += kitOrder.Price.Value;
            }

            newOrder.TotalPrice = totalPrice;
            _context.Orders.Add(newOrder);
            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            return newOrder;
        }

        public async Task<List<Order>> GetOrderByOrderId(int userId)
        {
            try
            {
                var orders = await _context.Orders
                    .Where(o => o.UserId == userId)
                    .OrderByDescending(o => o.OrderDay) 
                    .Include(o => o.KitOrders) 
                        .ThenInclude(ko => ko.Kit) 
                    .Select(o => new Order
                    {
                        Id = o.Id,
                        UserId = o.UserId,
                        OrderDay = o.OrderDay,
                        TotalPrice = o.TotalPrice,
                        Status = o.Status,
                        KitOrders = o.KitOrders.Select(ko => new KitOrder
                        {
                            KitId = ko.KitId,
                            Quantity = ko.Quantity,
                            Price = ko.Price,
                            Kit = new KitStem
                            {
                                Id = ko.Kit.Id,
                                Name = ko.Kit.Name,
                                price = ko.Kit.price,
                                Image = ko.Kit.Image
                            }
                        }).ToList()
                    })
                    .ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Order>(); 
            }
        }


        public async Task UpdateAsync(Lab lab)
        {
            _context.Entry(lab).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task<List<Order>> IOrderRepository.GetAll(int page, int pageSize, string? searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
