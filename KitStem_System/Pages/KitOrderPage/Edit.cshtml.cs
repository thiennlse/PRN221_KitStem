using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace KitStem_System.Pages.KitOrderPage
{
    public class EditModel : PageModel
    {
        private readonly BusinessObject.Models.KitStemDBContext _context;

        public EditModel(BusinessObject.Models.KitStemDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KitOrder KitOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.KitOrders == null)
            {
                return NotFound();
            }

            var kitorder =  await _context.KitOrders.FirstOrDefaultAsync(m => m.Id == id);
            if (kitorder == null)
            {
                return NotFound();
            }
            KitOrder = kitorder;
           ViewData["KitId"] = new SelectList(_context.KitStems, "Id", "Id");
           ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(KitOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitOrderExists(KitOrder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KitOrderExists(int id)
        {
          return (_context.KitOrders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
