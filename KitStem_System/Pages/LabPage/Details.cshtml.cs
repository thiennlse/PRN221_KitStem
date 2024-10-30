using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObject.Models;
using Service.Interface;

namespace KitStem_System.Pages.LabPage
{
    public class DetailsModel : PageModel
    {
        private readonly ILabService _labService;
        private readonly IKitService _kitService;
        public DetailsModel(ILabService labService, IKitService kitService)
        {
            _labService = labService;
            _kitService = kitService;
        }

        public Lab Lab { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                await _kitService.GetAll();
                Lab = await _labService.GetById(id);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            return Page();
        }
    }
}
