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
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                User =  await _userService.GetAll();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
    }
}
