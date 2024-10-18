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
        Task<List<Lab>> GetAll(int page, int pageSize, string searchTerm);

        Task UpdateAsync(Lab lab);
    }
}
