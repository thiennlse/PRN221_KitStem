using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace KitStem_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _service;

        public IndexModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            // Có thể xử lý gì đó trong phương thức GET (nếu cần)
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string email = Request.Form["txtUsername"];
            string password = Request.Form["txtPassword"];

            User user = await _service.Login(email, password);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Email or Password is incorrect!";
                return RedirectToPage("/Index");
            }


            HttpContext.Session.SetInt32("userid", user.Id);
            HttpContext.Session.SetInt32("roleid", (int)user.Role);
            HttpContext.Session.SetString("username", user.Name);


            if (user.Role == 1)
            {
                return RedirectToPage("/KitShopPage/ViewKitShop");
            }

            if (user.Role == 2)
            {
                return RedirectToPage("/KitPage/Index");
            }

            return RedirectToPage("/Index");
        }
    }
}
