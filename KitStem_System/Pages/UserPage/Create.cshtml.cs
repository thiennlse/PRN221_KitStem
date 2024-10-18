using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Service.Interface;
using BusinessObject.RequestModel;

namespace KitStem_System.Pages.UserPage
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _service;

        public CreateModel(IUserService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UserRequest User { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (User == null) 
            {
                return Page();
            }

            await _service.Register(User);
            return RedirectToPage("./Index");
        }
    }
}
