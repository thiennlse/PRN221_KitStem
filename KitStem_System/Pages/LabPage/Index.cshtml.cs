using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.LabPage
{
    public class IndexModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IKitService _kitService;
        public IndexModel(ILabService labService, IKitService kitService)
        {
            _labService = labService;
            _kitService = kitService;
        }

        public IList<Lab> Labs { get; set; } = default!;
        [BindProperty]
        public int listPage { get; set; } = 1;

        public int pageSize = 100;

        [BindProperty(SupportsGet = true)]
        public string? txtSearch { get; set; } = default!;
        public async Task OnGetAsync()
        {
            try
            {
                await _kitService.GetAll();
                Labs = await _labService.GetAll(listPage, pageSize, txtSearch);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
