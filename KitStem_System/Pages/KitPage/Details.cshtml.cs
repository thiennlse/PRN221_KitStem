using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitStem_System.Pages.KitPage
{
    public class DetailsModel : PageModel
    {
        private readonly IKitService _kitStemService;  
        private readonly ILabService _labService;         

        public DetailsModel(IKitService kitStemService, ILabService labService)
        {
            _kitStemService = kitStemService;
            _labService = labService;
        }

        public KitStem KitStem { get; set; } = default!;
        public List<Lab> Labs { get; set; } = new List<Lab>(); 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitStem = await _kitStemService.GetById(id.Value);  
            if (kitStem == null)
            {
                return NotFound();
            }
            KitStem = kitStem;

            Labs = await _labService.GetByKitId(kitStem.Id);  

            return Page();
        }
    }
}
