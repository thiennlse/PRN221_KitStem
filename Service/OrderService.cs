using BusinessObject.Models;
using PayPal;
using PayPal.Api;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public Task<BusinessObject.Models.Order> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task Update(int id, BusinessObject.Models.Order order)
        {
            order.Id = id;
            await _repository.UpdateAsync(order);
        }

        private APIContext GetAPIContext()
        {
            var clientId = "AVxahSSl4ARDEASlB4bb-DDlwidxh7PHKCytZI-N-1TEoOrHt6iLYFBuYs8V4aZOPW_YSmDbbr1t2WYf";
            var clientSecret = "EFedTfMAt61pQ7JWAArZEHU3iMg2BY3D4sRrMIX9Jezl16g8mkk2XwZg0HUzWoVbumrPlv0gy85n7i6o";
            var accessToken = new OAuthTokenCredential(clientId, clientSecret).GetAccessToken();
            return new APIContext(accessToken) { Config = new Dictionary<string, string> { { "mode", "sandbox" } } };
        }

        public Payment CreatePayPalPayment(decimal total, string successUrl, string cancelUrl)
        {
            var apiContext = GetAPIContext();
            decimal newTotal = Math.Round(total, 2); 
            Console.WriteLine($"Converted total: {newTotal}");

            var transactionList = new List<Transaction>
            {
                new Transaction
                {
                    description = "Payment for booking",
                    invoice_number = new Random().Next(100000).ToString(),
                    amount = new Amount
                    {
                        currency = "USD",
                        total = newTotal.ToString("F2")
                    }
                }
            };

            var payment = new Payment
            {
                intent = "sale",
                payer = new Payer { payment_method = "paypal" },
                transactions = transactionList,
                redirect_urls = new RedirectUrls
                {
                    cancel_url = "https://localhost:7093/CartShopPage/CartShop",
                    return_url = "https://localhost:7093/OrderPage/OrderHistory"
                },
            };

            try
            {
                var createdPayment = payment.Create(apiContext);

                var approvalUrl = createdPayment.links
                    .FirstOrDefault(link => link.rel == "approval_url")?.href;

                return createdPayment;
            }


            catch (PayPalException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Error while creating PayPal payment", ex);
            }
        }
 
        public Task<BusinessObject.Models.Order> CreateOrder(List<CartItem> cartItems)
        {
            return _repository.CreateOrder(cartItems);
        }

        public Task<List<BusinessObject.Models.Order>> GetOrdersByUserId(int userId)
        {
            return _repository.GetOrderByOrderId(userId);
        }

        public async Task<List<KitStem>> GetKitByUserId(int userId)
        {
            var orders = await _repository.GetOrderByOrderId(userId);
            var kits = orders
                    .SelectMany(order => order.KitOrders)
                    .Select(kitOrder => kitOrder.Kit)
                    .DistinctBy(kit => kit.Id)
                    .ToList();

            return kits;
        }
    }
}
