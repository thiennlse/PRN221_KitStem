using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KitStem_System.Pages.KitShopPage
{
    public class KitDetailShopModel : PageModel
    {
        private readonly IKitService _kitService;
        private readonly ICartItemService _cartItemService;
        public KitStem Kit { get; set; }
        public List<KitStem> RelatedKits { get; set; }

        public KitDetailShopModel(IKitService kitService, ICartItemService cartItemService)
        {
            _kitService = kitService;
            _cartItemService = cartItemService;
        }

        public async Task OnGetAsync(int id)
        {
            Kit = await _kitService.GetById(id);
            RelatedKits = (await _kitService.GetAll()).Take(4).ToList();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int kitId, int quantity)
        {
            var userId = HttpContext.Session.GetInt32("userid");
            var kit = await _kitService.GetById(kitId);
            if (quantity > kit.quantity)
            {
                HttpContext.Session.SetString("Error", "Not enough quantity");
                return Page();
            }
            else
            {
                await _cartItemService.AddCartItem((int)userId, kitId, quantity);

                return RedirectToPage("/KitShopPage/KitDetailShop", new { id = kitId });
            }
        }

        public async Task<IActionResult> OnPostBuyNowAsync(int kitId, int quantity)
        {
            var userId = 1;

            await _cartItemService.AddCartItem(userId, kitId, quantity);

            return RedirectToPage("/CartShopPage/CartShop");
        }
    }
}
