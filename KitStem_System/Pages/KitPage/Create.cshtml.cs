using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;

namespace KitStem_System.Pages.KitPage
{
    public class CreateModel : PageModel
    {
        private readonly IKitService _kitStemService;
        private readonly FirebaseService _firebaseService;

        public CreateModel(IKitService kitStemService, FirebaseService firebaseService)
        {
            _kitStemService = kitStemService;
            _firebaseService = firebaseService;
        }

        [BindProperty]
        public KitStem Kit { get; set; } = new KitStem();

        public IFormFile ImageFile { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Kit.Image = await _firebaseService.UploadImageAsync(ImageFile);

            await _kitStemService.Add(Kit);
            return RedirectToPage("/KitPage/Index");
        }
    }
}
