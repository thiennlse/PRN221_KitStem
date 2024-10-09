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

        public async Task<User> Login(string username, string password)
        {
            return await _userRepository.Login(username, password);
        }

        public async Task Register(UserRequest user)
        {
            await _userRepository.Register(user);
        }
    }
}
