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
    public class StepService : IStepService
    {
        private readonly IStepRepository _repository;

        public StepService(IStepRepository repository)
        {
            _repository = repository;
        }
        public Task<Step> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public Task<Step> UpdateAsync(Step step)
        {
            return _repository.UpdateAsync(step);
        }
    }
}
