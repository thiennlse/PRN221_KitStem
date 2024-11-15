using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.KitOrderPage
{
    public class IndexModel : PageModel
    {
        private readonly IKitOrderService _kitService;


        public IndexModel(IKitOrderService kitService)
        {
            _kitService = kitService;
        }

        public IList<KitOrder> KitOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            KitOrder = await _kitService.GetAll();
        }
    }
}
