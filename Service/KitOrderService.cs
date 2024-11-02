using BusinessObject.Models;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class KitOrderService : IKitOrderService
    {
        private readonly IKitOrderRepository _kitOrderRepository;

        public KitOrderService(IKitOrderRepository kitOrderRepository)
        {
            _kitOrderRepository = kitOrderRepository;
        }

        public async Task Add(KitOrder order)
        {
            await _kitOrderRepository.Add(order);
        }

        public async Task<List<KitOrder>> GetAll()
        {
            return await _kitOrderRepository.GetAll();  
        }

        public async Task<KitOrder> GetById(int id)
        {
            return await _kitOrderRepository.GetById(id);    
        }

        public async Task Remove(int id)
        {
            await _kitOrderRepository.Remove(id);   
        }

        public async Task Update(KitOrder order)
        {
            await _kitOrderRepository.Update(order);
        }
    }
}
