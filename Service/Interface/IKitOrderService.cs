using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IKitOrderService
    {
        Task<List<KitOrder>> GetAll();

        Task<KitOrder> GetById(int id);

        Task Add(KitOrder order);

        Task Remove(int id);

        Task Update(KitOrder order);
    }
}
