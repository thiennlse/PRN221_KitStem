using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.LabPage
{
    public class EditModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IKitService _kitService;
        public EditModel(ILabService labService, IKitService kitService)
        {
            _labService = labService;
            _kitService = kitService;
        }

        [BindProperty]
        public Lab Lab { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Lab = await _labService.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            ViewData["KitId"] = new SelectList(await _kitService.GetAll(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await _labService.Update(id,Lab);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);    
            }

            return RedirectToPage("./Index");
        }
    }
}
