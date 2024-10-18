using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.UserPage
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;
        public DetailsModel(IUserService userService)
        {
            _userService = userService;
        }

      public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                User = await _userService.GetById(id);
            }
            catch(Exception ex)
            {
                throw;
            }
            return Page();
        }
    }
}
