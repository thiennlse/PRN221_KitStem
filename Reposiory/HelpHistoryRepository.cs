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
    public class HelpHistoryRepository : BaseRepository<HelpHistory>, IHelpHistoryRepository
    {
        private readonly KitStemDBContext _context;
        public HelpHistoryRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task CreateHelpHistoryAsync(HelpHistory helpHistory)
        {
            if (helpHistory == null)
            {
                throw new ArgumentNullException(nameof(helpHistory));
            }

            await _context.HelpHistories.AddAsync(helpHistory);

            await _context.SaveChangesAsync();
        }

        public async Task<HelpHistory> GetHelpHistoryAsync(int userLabId, int stepId)
        {
            return await _context.HelpHistories
                                 .FirstOrDefaultAsync(h => h.UserLabId == userLabId && h.StepId == stepId);
        }
    }
}
