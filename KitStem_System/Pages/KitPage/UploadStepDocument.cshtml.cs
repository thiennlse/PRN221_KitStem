using System.IO;
using System.Threading.Tasks;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;

namespace KitStem_System.Pages.KitPage
{
    public class UploadStepDocumentModel : PageModel
    {
        private readonly IStepService _stepService;
        private readonly FirebaseService _firebaseService;

        public UploadStepDocumentModel(IStepService stepService, FirebaseService firebaseService)
        {
            _stepService = stepService;
            _firebaseService = firebaseService;
        }

        [BindProperty]
        public IFormFile Document { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StepId { get; set; }

        public Step Step { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Step = await _stepService.GetById(StepId);
            if (Step == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Document == null)
            {
                return Page();
            }

            Step = await _stepService.GetById(StepId);
            if (Step == null)
            {
                return NotFound();
            }
            Step.Status = 1;
            Step.Description = await _firebaseService.UploadDocumentAsync(Document);

            await _stepService.UpdateAsync(Step);
            return RedirectToPage("./LabDetail", new { id = Step.LabId });
        }
    }
}
