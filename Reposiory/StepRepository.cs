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
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        private readonly KitStemDBContext _context;
        public StepRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Step> UpdateAsync(Step step)
        {
            if (step == null) throw new ArgumentNullException(nameof(step));

            var existingStep = await _context.Steps.FindAsync(step.Id);
            if (existingStep == null)
            {
                throw new KeyNotFoundException($"Step with ID {step.Id} was not found.");
            }

            _context.Entry(existingStep).CurrentValues.SetValues(step);

            try
            {
                await _context.SaveChangesAsync();
                return existingStep;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("An error occurred while updating the step in the database.", ex);
            }
        }
    }
}
