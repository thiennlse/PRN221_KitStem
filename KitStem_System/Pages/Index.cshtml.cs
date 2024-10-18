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
        [BindProperty]
        public string txtUsername { get; set; } = default!;
        [BindProperty]
        public string txtPassword { get; set; } = default!;

        public async Task OnPostAsync(string txtUsername , string txtPassword)
        {
            if(txtPassword != null && txtUsername != null)
            {
                await _service.Login(txtUsername, txtPassword);
                Response.Redirect("/UserPage/Index");
            }

        }
    }
}