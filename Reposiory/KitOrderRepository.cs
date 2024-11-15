using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class KitOrderRepository : BaseRepository<KitOrder>, IKitOrderRepository
    {
        public KitOrderRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<KitOrder>> GetAllAsync()
        {
            return await _dbSet
                .Include(o => o.Order)
                .Include(o => o.Kit)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<KitOrder> GetByIdAsync(int id)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id.Equals(id));
        }
    }
}
