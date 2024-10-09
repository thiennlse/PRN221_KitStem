using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.UnitOfWork;

namespace KitStem_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public IndexModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public string txtUsername { get; set; } = default!;
        [BindProperty]
        public string txtPassword { get; set; } = default!;

        public async Task OnPostAsync(string txtUsername , string txtPassword)
        {
            if(txtPassword != null && txtUsername != null)
            {
                await _unitOfWork.userRepository.Login(txtUsername, txtPassword);
                Response.Redirect("/Privacy");
            }

        }
    }
}