using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace KitStem_System.Pages.KitPage
{
    public class AddLabModel : PageModel
    {
        private readonly IKitService _kitService;
        private readonly ILabService _labService;


        public AddLabModel(IKitService kitService, ILabService labService)
        {
            _kitService = kitService;
            _labService = labService;
        }

        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string Step { get; set; }
        [BindProperty]
        public int MaxHelp { get; set; }
        [BindProperty]
        public int Status { get; set; }
        [BindProperty]
        public int DeadlineDate { get; set; }
        [BindProperty]

        public int KitStemId { get; set; }

        public void OnGet(int kitId)
        {
            KitStemId = kitId;
        }

        public async Task<IActionResult> OnPostAsync(int kitId)
        {
            // Use the service to add a lab
            await _labService.AddLabAsync(kitId, Description, Step, MaxHelp,DeadlineDate, Status);

            // Redirect to the KitStem details page after adding the lab
            return RedirectToPage("./Details", new { id = kitId });
        }
    }
}
