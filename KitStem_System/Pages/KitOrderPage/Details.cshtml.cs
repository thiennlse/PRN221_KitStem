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
    public class DetailsModel : PageModel
    {
        private readonly BusinessObject.Models.KitStemDBContext _context;

        public DetailsModel(BusinessObject.Models.KitStemDBContext context)
        {
            _context = context;
        }

      public KitOrder KitOrder { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KitOrders == null)
            {
                return NotFound();
            }

            var kitorder = await _context.KitOrders.FirstOrDefaultAsync(m => m.Id == id);
            if (kitorder == null)
            {
                return NotFound();
            }
            else 
            {
                KitOrder = kitorder;
            }
            return Page();
        }
    }
}
