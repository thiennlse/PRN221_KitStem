using BusinessObject.Models;
using BusinessObject.RequestModel;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderService
    {

        Task<BusinessObject.Models.Order> GetById(int id);
        Payment CreatePayPalPayment(decimal total, string SuccessUrl, string cancelUrl);
        Task<BusinessObject.Models.Order> CreateOrder(List<CartItem> cartItems);
        Task<List<BusinessObject.Models.Order>> GetOrdersByUserId(int userId);
        Task<List<KitStem>> GetKitByUserId(int UserId);
    }
}
