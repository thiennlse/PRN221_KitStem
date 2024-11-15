using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace KitStem_System.Pages.KitPage
{
    public class LabDetailModel : PageModel
    {
        private readonly ILabService _labService;

        public LabDetailModel(ILabService labService)
        {
            _labService = labService;
        }

        public Lab Lab { get; set; }

        public IActionResult OnGet(int id)
        {
            Lab = _labService.GetLabWithSteps(id);

            if (Lab == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
