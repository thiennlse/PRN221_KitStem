using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IHelpHistoryRepository : IBaseRepository<HelpHistory>
    {
        Task CreateHelpHistoryAsync(HelpHistory helpHistory);
        Task<HelpHistory> GetHelpHistoryAsync(int id, int stepId);
    }
}
