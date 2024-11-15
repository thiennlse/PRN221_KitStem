using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace KitStem_System.OrderPage
{
    public class OrderHistoryModel : PageModel
    {
        private readonly IOrderService _orderService;
        public List<Order> Orders { get; set; }

        public OrderHistoryModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("userid") ?? 0;
            Orders = await _orderService.GetOrdersByUserId(userId);
        }
    }
}
