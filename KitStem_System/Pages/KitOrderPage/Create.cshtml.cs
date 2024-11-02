using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;

namespace KitStem_System.Pages.KitOrderPage
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObject.Models.KitStemDBContext _context;

        public CreateModel(BusinessObject.Models.KitStemDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["KitId"] = new SelectList(_context.KitStems, "Id", "Id");
        ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public KitOrder KitOrder { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.KitOrders == null || KitOrder == null)
            {
                return Page();
            }

            _context.KitOrders.Add(KitOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
