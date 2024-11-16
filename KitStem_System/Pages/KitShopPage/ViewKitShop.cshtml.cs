using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitStem_System.Pages.KitShopPage
{
    public class ViewKitShopModel : PageModel
    {
        private readonly IKitService _kitService;

        public ViewKitShopModel(IKitService kitService)
        {
            _kitService = kitService;
        }

        public List<KitStem> Kits { get; set; }
        public string SearchTerm { get; set; }

        public async Task OnGetAsync(string searchTerm = "")
        {
            SearchTerm = searchTerm;
            Kits = await _kitService.GetAllAsync(1, 10, searchTerm);
        }
    }
}
