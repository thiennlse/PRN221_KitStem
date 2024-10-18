using BusinessObject.Models;
using BusinessObject.RequestModel;
using Reposiory;
using Reposiory.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteById(int id)
        {
            await _userRepository.Remove(id);
        }

        public Task<List<User>> GetAll()
        {
           return _userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> Login(string username, string password)
        {
            return await _userRepository.Login(username, password);
        }

        public async Task Register(UserRequest user)
        {
            await _userRepository.Register(user);
        }

        public async Task Update(User user)
        {
           await _userRepository.UpdateAsync(user);
        }
    }
}
