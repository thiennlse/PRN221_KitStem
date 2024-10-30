using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.LabPage
{
    public class CreateModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IKitService _kitService;

        public CreateModel(ILabService labService, IKitService kitService)
        {
            _labService = labService;
            _kitService = kitService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            List<KitStem> kit = await _kitService.GetAll();
            ViewData["KitId"] = new SelectList( kit, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Lab Lab { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _labService.Add(Lab);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return RedirectToPage("./Index");
        }
    }
}
