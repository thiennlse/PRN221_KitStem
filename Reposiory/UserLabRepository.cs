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
    public class UserLabRepository : BaseRepository<UserLab>, IUserLabRepository
    {
        private readonly KitStemDBContext _context;
        public UserLabRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> EnrollUserInLabAsync(int userId, int labId)
        {
            var existingEnrollment = await _context.UserLabs
                .FirstOrDefaultAsync(ul => ul.UserId == userId && ul.LabId == labId);

            if (existingEnrollment != null)
            {
                return false; 
            }

            var lab = await _context.Labs
                .FirstOrDefaultAsync(l => l.Id == labId);

            var userLab = new UserLab
            {
                UserId = userId,
                LabId = labId,
                Deadline = DateTime.Now.AddDays((double)lab.DeadlineDay),
                HelpRemaining = lab.MaxHelp
            };

            _context.UserLabs.Add(userLab);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserLab> GetByLabId(int labId, int userId)
        {
            var userLab = await _context.UserLabs
                .Include(ul => ul.HelpHistories) 
                .FirstOrDefaultAsync(ul => ul.LabId == labId && ul.UserId == userId);

            if (userLab == null)
            {
                throw new KeyNotFoundException($"No UserLab found for LabId {labId} and UserId {userId}.");
            }

            return userLab;
        }

        public async Task<bool> IsUserEnrolledInLabAsync(int userId, int labId)
        {
            bool result = await _context.UserLabs
                .AnyAsync(ul => ul.UserId == userId && ul.LabId == labId);

            return result;
        }

        public Task<UserLab> UpdateAsync(UserLab userLab)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserLabAsync(UserLab userLab)
        {
            if (userLab == null)
            {
                throw new ArgumentNullException(nameof(userLab), "UserLab cannot be null.");
            }

            var existingUserLab = await _context.UserLabs.FindAsync(userLab.Id);

            if (existingUserLab == null)
            {
                throw new KeyNotFoundException($"UserLab with ID {userLab.Id} not found.");
            }

            existingUserLab.Deadline = userLab.Deadline;
            existingUserLab.ImageUrl = userLab.ImageUrl;
            existingUserLab.HelpRemaining = userLab.HelpRemaining;
            existingUserLab.LabId = userLab.LabId;
            existingUserLab.UserId = userLab.UserId;

            await _context.SaveChangesAsync();
        }
    }
}
