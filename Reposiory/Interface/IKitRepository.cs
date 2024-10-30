using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IKitRepository : IBaseRepository<KitStem>
    {
        Task<List<KitStem>> GetAllAsync(int page, int pageSize, string? searchTerm);
    }
}
