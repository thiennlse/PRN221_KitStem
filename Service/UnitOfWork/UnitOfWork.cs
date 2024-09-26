using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.UnitOfWork
{
    public class UnitOfWork
    {
        private UserRepository _userRepository;

        private KitStemDBContext _dbContext;

        public UnitOfWork(KitStemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRepository userRepository
        {
            get
            {
                if( _userRepository == null )
                {
                    _userRepository = new UserRepository( _dbContext );
                }
                return _userRepository;
            }
        }
    }
}
