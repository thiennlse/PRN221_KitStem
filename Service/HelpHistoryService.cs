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
    public class HelpHistoryService : IHelpHistoryService
    {
        private readonly IHelpHistoryRepository _repository;

        public HelpHistoryService(IHelpHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateHelpHistoryAsync(HelpHistory helpHistory)
        {
            await _repository.CreateHelpHistoryAsync(helpHistory);
        }

        public async Task<HelpHistory> GetHelpHistoryAsync(int id, int stepId)
        {
            return await _repository.GetHelpHistoryAsync(id, stepId);
        }
    }
}
