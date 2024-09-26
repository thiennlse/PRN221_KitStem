using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Login(string username, string password);

    }
}
