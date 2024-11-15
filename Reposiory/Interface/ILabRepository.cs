using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface ILabRepository : IBaseRepository<Lab>
    {
        Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm);

        Task UpdateAsync(Lab lab);
        Task<List<Lab>> GetByKitId(int kitId);
        Task AddLabAsync(int kitId, string description, string step, int maxHelp,int deadlineDate, int status);
        Lab GetLabWithSteps(int labId);
    }
}
