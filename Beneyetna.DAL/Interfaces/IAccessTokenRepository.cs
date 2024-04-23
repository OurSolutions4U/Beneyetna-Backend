using Beneyetna.DAL.Repositories;
using Beneyetna.DataContracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DAL.Interfaces
{
    public interface IAccessTokenRepository
    {
        public Task<AccessToken> AddAccessToken(AccessToken accessToken);
        public Task<AccessToken> GetActiveAccessToken(long userID);
        public Task UpdateAccessToken(AccessToken accessToken);

        //public Task<User> GetUserByEmail(string email);
    }
}
