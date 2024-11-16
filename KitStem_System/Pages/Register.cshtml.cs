using BusinessObject.Models;
using BusinessObject.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;

namespace KitStem_System.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _service;

        public RegisterModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string username = Request.Form["txtUsername"];
            string password = Request.Form["txtPassword"];
            string confirmPassword = Request.Form["txtConfirmPassword"];

            // Validate inputs
            if (password != confirmPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match!";
                return Page();
            }
            UserRequest newUser = new UserRequest
            {
                Username = username,
                Password = password,
            };

            await _service.Register(newUser);

            TempData["SuccessMessage"] = "Registration successful! Please log in.";
            return RedirectToPage("/Index");
        }
    }
}
