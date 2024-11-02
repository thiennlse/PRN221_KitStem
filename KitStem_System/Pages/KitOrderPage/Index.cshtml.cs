using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace KitStem_System.Pages.KitOrderPage
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.KitStemDBContext _context;

        public IndexModel(BusinessObject.Models.KitStemDBContext context)
        {
            _context = context;
        }

        public IList<KitOrder> KitOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.KitOrders != null)
            {
                KitOrder = await _context.KitOrders
                .Include(k => k.Kit)
                .Include(k => k.Order).ToListAsync();
            }
        }
    }
}
