using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface; 
using BusinessObject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace KitStem_System.Pages.KitPage
{
    public class IndexModel : PageModel
    {
        private readonly IKitService _kitService;

        public IndexModel(IKitService kitService)
        {
            _kitService = kitService;
        }

        public IList<KitStem> KitStem { get; set; } = default!;

        public async Task OnGetAsync()
        {
            KitStem = await _kitService.GetAll(); 
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            // Sign out the user
            await HttpContext.SignOutAsync();

            // Redirect to Index page
            return RedirectToPage("/Index");
        }
    }
}
