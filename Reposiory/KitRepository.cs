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
    public class KitRepository : BaseRepository<KitStem>, IKitRepository
    {
        private readonly KitStemDBContext _context;

        public KitRepository(KitStemDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<KitStem>> GetAllAsync(int page, int pageSize, string? searchTerm)
        {
            var query = GetQueryable<KitStem>();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(l => l.Attribute.Contains(searchTerm));
            }
            var result = await query.Skip((page - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return result;

        }
    }
}
