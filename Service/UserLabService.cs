using BusinessObject.Models;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserLabService : IUserLabService
    {
        private readonly IUserLabRepository _repository;

        public UserLabService(IUserLabRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> EnrollUserInLabAsync(int userId, int labId)
        {
            return _repository.EnrollUserInLabAsync(userId, labId);
        }

        public Task<UserLab> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public async Task<UserLab> GetByLabId(int labId, int userId)
        {
            return await _repository.GetByLabId(labId, userId);
        }

        public Task<bool> IsUserEnrolledInLabAsync(int userId, int id)
        {
            return _repository.IsUserEnrolledInLabAsync(userId, id);
        }

        public Task<UserLab> UpdateAsync(UserLab userLab)
        {
            return _repository.UpdateAsync(userLab);
        }

        public Task UpdateUserLabAsync(UserLab userLab)
        {
            return _repository.UpdateUserLabAsync(userLab);
        }
    }
}
