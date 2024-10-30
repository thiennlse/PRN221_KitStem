using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class LabRepository : BaseRepository<Lab>, ILabRepository
    {
        private readonly KitStemDBContext _context;
        public LabRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Lab>> GetAll(int page, int pageSize, string? searchTerm)
        {
            var query = GetQueryable().AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(l => l.Description.Contains(searchTerm));
            }
            var result = await query.Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return result;
        }

        public async Task UpdateAsync(Lab lab)
        {
            _context.Entry(lab).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
