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

        public async Task<List<Lab>> GetByKitId(int kitId)
        {
            return await _context.Labs
                                 .Where(l => l.KitId == kitId)
                                 .ToListAsync();
        }

        public async Task AddLabAsync(int kitId, string description, string step, int maxHelp,int deadlineDate, int status)
        {
            var lab = new Lab
            {
                KitId = kitId,
                Description = description,
                Step = int.TryParse(step, out var parsedStep) ? parsedStep : 0,
                MaxHelp = maxHelp,
                DeadlineDay= deadlineDate,
                Status = status
            };

            _context.Labs.Add(lab);
            await _context.SaveChangesAsync();

            if (lab.Step.HasValue && lab.Step.Value > 0)
            {
                var steps = new List<Step>();

                for (int i = 1; i <= lab.Step.Value; i++)
                {
                    var stepEntity = new Step
                    {
                        LabId = lab.Id,
                        ThisStep = i,
                        Status = 0
                    };

                    steps.Add(stepEntity);
                }

                _context.Steps.AddRange(steps);
                await _context.SaveChangesAsync();
            }
        }

        public Lab GetLabWithSteps(int labId)
        {
            return _context.Labs
                .Include(l => l.Steps)
                .ThenInclude(s => s.HelpHistories)
                .FirstOrDefault(l => l.Id == labId);
        }
    }
}
