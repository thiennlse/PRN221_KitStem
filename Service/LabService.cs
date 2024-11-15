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
    public class LabService : ILabService
    {
        private readonly ILabRepository _repository;

        public LabService(ILabRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(Lab lab)
        {
            await _repository.Add(lab);
        }

        public async Task Delete(int id)
        {
            await _repository.Remove(id);
        }

        public async Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm)
        {
            return await _repository.GetAll(page, pageSize, searchTerm);
        }

        public async Task<Lab> GetById(int id)
        {
            return await _repository.GetById(id); 
        }

        public async Task Update(int id,Lab lab)
        {
            lab.Id = id;
            await _repository.UpdateAsync(lab);
        }

        public async Task<List<Lab>> GetByKitId(int kitId)
        {
            return await _repository.GetByKitId(kitId);
        }

        public async Task AddLabAsync(int kitId, string description, string step, int maxHelp,int deadlineDate, int status)
        {
            await _repository.AddLabAsync(kitId, description, step, maxHelp, deadlineDate, status);
        }

        public Lab GetLabWithSteps(int labId)
        {
            return _repository.GetLabWithSteps(labId);
        }
    }
}
