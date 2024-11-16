using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;

namespace KitStem_System.Pages.MyKit
{
    public class MyLabModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IUserLabService _userLabService;
        private readonly IHelpHistoryService _helpHistoryService;

        public MyLabModel(ILabService labService, IUserLabService userLabService, IHelpHistoryService helpHistoryService)
        {
            _labService = labService;
            _userLabService = userLabService;
            _helpHistoryService = helpHistoryService;
        }

        public Lab Lab { get; set; }
        public UserLab UserLab { get; set; }
        public List<Step> Steps { get; set; }

        public async Task<IActionResult> OnGetAsync(int labId)
        {

            var userId = HttpContext.Session.GetInt32("userid") ?? 0;

            Lab = _labService.GetLabWithSteps(labId);

            if (Lab == null)
            {
                return RedirectToPage("/Error");
            }
            UserLab = await _userLabService.GetByLabId(labId, userId);

            Steps = Lab.Steps?
                     .ToList() ?? new List<Step>();
            return Page();
        }

        public async Task<IActionResult> OnPostHelpAsync(int stepId, int labId)
        {
            var userId = HttpContext.Session.GetInt32("userid") ?? 0;

            var userLab = await _userLabService.GetByLabId(labId, userId);
            if (userLab == null || userLab.HelpRemaining <= 0)
            {
                TempData["Error"] = "You have no remaining help requests.";
                return RedirectToPage();
            }

            var helpHistory = new HelpHistory
            {
                UserLabId = userLab.Id,
                StepId = stepId,
            };

            await _helpHistoryService.CreateHelpHistoryAsync(helpHistory);

            userLab.HelpRemaining -= 1;
            await _userLabService.UpdateUserLabAsync(userLab);

            TempData["Success"] = "Help request has been submitted successfully.";
            return RedirectToPage(new { labId = labId });
        }

    }
}