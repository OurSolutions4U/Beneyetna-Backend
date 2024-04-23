using Beneyetna.Core;
using Beneyetna.DAL.Interfaces;
using Beneyetna.DataContracts.Context;
using Beneyetna.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DAL.Repositories
{
    public class UserRepository : IUserRepository 
    {
        private readonly IBaseRepository<User> _UserRepository;


        public UserRepository(IBaseRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public Task<User> AddUser(User user)
        {

            return _UserRepository.AddAsync(user);
        }
        public Task<User> GetUserByEmail(string email)
        {
            return _UserRepository.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
