using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using Reposiory.Interface;
using Service.Interface;

namespace KitStem_System.Pages.MyKit
{
    public class MyKitModel : PageModel
    {
        private readonly IOrderService _orderService;
        public List<KitStem> Kits { get; set; } = new List<KitStem>();

        public MyKitModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("userid") ?? 0;

            var orders = await _orderService.GetKitByUserId(userId);
            Kits = orders;
        }
    }
}
