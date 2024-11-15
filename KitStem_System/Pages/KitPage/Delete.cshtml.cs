using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using BusinessObject.Models;

namespace KitStem_System.Pages.KitPage
{
    public class DeleteModel : PageModel
    {
        private readonly IKitService _kitService;

        public DeleteModel(IKitService kitService)
        {
            _kitService = kitService;
        }

        [BindProperty]
        public KitStem KitStem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            KitStem = await _kitService.GetById(id.Value);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _kitService.Delete(id.Value);


            return RedirectToPage("./Index");
        }
    }
}
