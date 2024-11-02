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
    public class KitService : IKitService
    {
        private readonly IKitRepository _kitRepository;

        public KitService(IKitRepository kitRepository)
        {
            _kitRepository = kitRepository;
        }   

        public async Task Add(KitStem item)
        {
            await _kitRepository.Add(item);
        }

        public async Task Delete(int id)
        {
            await _kitRepository.Remove(id);
        }

        public async Task<List<KitStem>> GetAll()
        {
            return await _kitRepository.GetAll(); 
        }

        public async Task<List<KitStem>> GetAllAsync(int page, int pageSize, string? searchTerm)
        {
            return await _kitRepository.GetAllAsync(page, pageSize, searchTerm);
        }

        public Task<KitStem> GetById(int id)
        {
            return _kitRepository.GetById(id);
        }

        public async Task Update(KitStem item)
        {
            await _kitRepository.Update(item);
        }
    }
}
