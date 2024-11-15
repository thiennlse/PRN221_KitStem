using BusinessObject.Models;
using BusinessObject.RequestModel;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserLabService
    {
        Task<bool> EnrollUserInLabAsync(int userId, int labId);
        Task<UserLab> GetById(int id);
        Task<UserLab> GetByLabId(int labId, int userId);
        Task<bool> IsUserEnrolledInLabAsync(int userId, int id);
        Task<UserLab> UpdateAsync(UserLab userLab);
        Task UpdateUserLabAsync(UserLab userLab);
    }
}
