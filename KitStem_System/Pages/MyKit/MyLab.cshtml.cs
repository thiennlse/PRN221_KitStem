using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public bool CanHelp { get; set; } = false;

        public async Task OnGetAsync(int labId)
        {
            Lab = _labService.GetLabWithSteps(labId);
            if (Lab == null) return;

            int userId = 1;
            UserLab = await _userLabService.GetByLabId(labId, userId);

            if (UserLab != null)
            {
                CanHelp = UserLab.HelpRemaining > 0;
            }
        }

        public async Task<IActionResult> OnPostHelpAsync(int stepId, int labId)
        {
            int userId = 1;
            UserLab = await _userLabService.GetByLabId(labId, userId);

            if (UserLab == null || UserLab.HelpRemaining <= 0)
            {
                return RedirectToPage("/MyKit/MyLab", new { labId = labId });
            }

            var existingHelp = await _helpHistoryService.GetHelpHistoryAsync(UserLab.Id, stepId);
            if (existingHelp != null)
            {
                return RedirectToPage("/MyKit/MyLab", new { labId = labId });
            }

            var helpHistory = new HelpHistory
            {
                UserLabId = UserLab.Id,
                StepId = stepId
            };
            await _helpHistoryService.CreateHelpHistoryAsync(helpHistory);

            UserLab.HelpRemaining--;
            await _userLabService.UpdateUserLabAsync(UserLab);

            return RedirectToPage("/MyKit/MyLab", new { labId = labId });
        }
    }
}