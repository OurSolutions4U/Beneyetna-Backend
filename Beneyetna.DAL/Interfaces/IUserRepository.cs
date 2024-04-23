using Beneyetna.DAL.Repositories;
using Beneyetna.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddUser(User user);
        public Task<User> GetUserByEmail(string email);
    }
}
