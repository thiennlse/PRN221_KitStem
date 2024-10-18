using BusinessObject.Models;
using BusinessObject.RequestModel;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly KitStemDBContext _context;
        private UserRepository instance;

        public UserRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> Login(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync( u => u.Username == username && u.Password == password);
        }

        public async Task Register(UserRequest user)
        {
            User _user = new User
            {
                Name = "New commer",
                Username = user.Username,
                Password = user.Password,
                Role = 1,
                Status = 1
            };
            _context.Users.Add(_user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
             await _context.SaveChangesAsync();   
        }
    }
}
