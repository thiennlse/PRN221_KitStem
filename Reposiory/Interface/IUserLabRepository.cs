using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IUserLabRepository : IBaseRepository<UserLab>
    {
        Task<bool> EnrollUserInLabAsync(int userId, int labId);
        Task<UserLab> GetByLabId(int labId, int userId);
        Task<bool> IsUserEnrolledInLabAsync(int userId, int id);
        Task<UserLab> UpdateAsync(UserLab userLab);
        Task UpdateUserLabAsync(UserLab userLab);
    }
}
