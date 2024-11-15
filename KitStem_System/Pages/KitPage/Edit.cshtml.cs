using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using BusinessObject.Models;
using Service;

namespace KitStem_System.Pages.KitPage
{
    public class EditModel : PageModel
    {
        private readonly IKitService _kitService;
        private readonly FirebaseService _firebaseService;

        public EditModel(IKitService kitService, FirebaseService firebaseService)
        {
            _kitService = kitService;
            _firebaseService = firebaseService;
        }

        [BindProperty]
        public KitStem KitStem { get; set; } = default!;

        // Property for handling image file upload
        [BindProperty]
        public IFormFile? UploadedImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitstem = await _kitService.GetById(id.Value);

            if (kitstem == null)
            {
                return NotFound();
            }

            KitStem = kitstem;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedImage != null)
            {
                KitStem.Image = await _firebaseService.UploadImageAsync(UploadedImage);
            }

            else
            {
                var kit = await _kitService.GetById(KitStem.Id);
                KitStem.Image = kit.Image;
            }

             await _kitService.Update(KitStem);

            return RedirectToPage("./Index");
        }
    }
}
