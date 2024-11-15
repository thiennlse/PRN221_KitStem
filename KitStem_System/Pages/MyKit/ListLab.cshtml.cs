using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using BusinessObject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KitStem_System.Pages.MyKit
{
    public class ListLabModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IUserLabService _userLabService;

        public ListLabModel(ILabService labService, IUserLabService userLabService)
        {
            _labService = labService;
            _userLabService = userLabService;
        }

        public List<Lab> Labs { get; set; } = new List<Lab>();
        public Dictionary<int, bool> LabEnrollmentStatuses { get; set; } = new Dictionary<int, bool>();

        public int KitId { get; set; } 

        public async Task OnGetAsync(int kitId)
        {
            KitId = kitId;  
            Labs = await _labService.GetByKitId(kitId);

            int userId = 1;
            foreach (var lab in Labs)
            {
                LabEnrollmentStatuses[lab.Id] = await _userLabService.IsUserEnrolledInLabAsync(userId, lab.Id);
            }
        }

        public async Task<IActionResult> OnPostEnrollAsync(int labId, int kitId)
        {
            int userId = 1; 

            var success = await _userLabService.EnrollUserInLabAsync(userId, labId);

            if (success)
            {
                return RedirectToPage("/MyKit/ListLab", new { kitId = kitId });
            }

            return RedirectToPage("/MyKit/ListLab", new { kitId = kitId });
        }
    }
}
