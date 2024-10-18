using BusinessObject.Models;
using BusinessObject.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<User> Login(string username, string password);

        Task Register(UserRequest user);

        Task<List<User>> GetAll();  

        Task<User> GetById(int id);

        Task Update(User user);

        Task DeleteById(int id);    
    }
}
