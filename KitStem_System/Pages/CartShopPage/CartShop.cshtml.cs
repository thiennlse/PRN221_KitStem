using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using static System.Net.WebRequestMethods;

namespace KitStem_System.Pages.CartShopPage
{
    public class CartShopModel : PageModel
    {
        private readonly IKitService _kitService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        public List<CartItem> Cart { get; set; } = new List<CartItem>();

        public CartShopModel(IKitService kitService, ICartItemService cartItemService, IOrderService orderService)
        {
            _kitService = kitService;
            _cartItemService = cartItemService;
            _orderService = orderService;
        }

        private int GetUserId()
        {
            return HttpContext.Session.GetInt32("userid") ?? 0;
        }

        public decimal TotalPrice = 0;

        public async Task OnGetAsync()
        {
            var userId = GetUserId();
            Cart = await _cartItemService.GetCartItemsByUserId(userId);
            TotalPrice = (decimal)Cart.Sum(item => item.Kit.price * item.Quantity);

        }


        public async Task<IActionResult> OnPostChangeQuantity(int itemId, int amount)
        {
            var item = await _cartItemService.GetById(itemId);
            if (item != null)
            {
                var newkit = await _kitService.GetById(item.KitId);

                int newQuantity = (int)(item.Quantity + amount);
                if (newQuantity < 1)
                {
                    newQuantity = 1; 
                }
                else if (newQuantity > newkit.quantity)
                {
                    return RedirectToPage("/Error", new { message = "Quantity exceeds available stock." });
                }

                item.Quantity = newQuantity;

                await _cartItemService.UpdateAsync(item);
            }

            return RedirectToPage();
        }

        public IActionResult OnPostRemoveItem(int itemId)
        {
            _cartItemService.DeleteById(itemId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            Cart = await _cartItemService.GetCartItemsByUserId(1);

            TotalPrice = (decimal)Cart.Sum(item => item.Kit.price * item.Quantity);

            var createdPayment = _orderService.CreatePayPalPayment(TotalPrice,
                Url.Page("CartShop", new { area = "" }),
                Url.Page("CartShop", new { area = "" }));

            var approvalUrl = createdPayment.links
                .FirstOrDefault(link => link.rel == "approval_url")?.href;

            if (!string.IsNullOrEmpty(approvalUrl))
            {
                await _orderService.CreateOrder(Cart);
                return Redirect(approvalUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error creating PayPal payment. Please try again.");
                return Page();
            }
        }
    }
}
