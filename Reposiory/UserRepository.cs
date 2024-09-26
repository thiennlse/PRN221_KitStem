using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiory
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        private readonly KitStemDBContext _dBContext;
        private readonly BaseRepository<User> _baseRepository;

        public UserRepository(KitStemDBContext dbContext) : base(dbContext)
        {
            _dBContext = dbContext;
            _baseRepository = new BaseRepository<User>(_dBContext);
        }

        public async Task add(User entity)
        {
             await _baseRepository.add(entity);
        }

        public async Task deleteById(int id)
        {
            await _baseRepository.deleteById(id);
        }

        public async Task<List<User>> getAll()
        {
            return await _baseRepository.getAll();  
        }

        public async Task<User> getById(int id)
        {
            return await _baseRepository.getById(id);
        }

        public async Task<User> Login(string username, string password)
        {
            return await _dBContext.Users.
                FirstOrDefaultAsync(u => u.Username.Equals(username) && u.Password.Equals(password));
        }

        public async Task<User> update(User entity)
        {
            return await _baseRepository.update(entity);
        }
    }
}
