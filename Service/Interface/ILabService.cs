using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ILabService
    {
        Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm);

        Task<Lab> GetById(int id);
        Task Add(Lab lab);

        Task Update(int id,Lab lab);

        Task Delete(int id);

        Task<List<Lab>> GetByKitId(int kitId);
        Task AddLabAsync(int kitId, string description, string step, int maxHelp,int DeadlineDate, int status);
        Lab GetLabWithSteps(int labId);
    }
}
