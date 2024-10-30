using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IKitService
    {
        Task<List<KitStem>> GetAllAsync(int page, int pageSize, string? searchTerm);
        Task<List<KitStem>> GetAll();
        Task<KitStem> GetById( int id );
        Task Add(KitStem item);
        Task Update(KitStem item);
        Task Delete(int id);
    }
}
