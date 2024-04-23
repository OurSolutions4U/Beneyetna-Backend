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
    public class AccessTokenRepository : IAccessTokenRepository 
    {
        private readonly IBaseRepository<AccessToken> _AccessTokenRepository;


        public AccessTokenRepository(IBaseRepository<AccessToken> AccessTokenRepository)
        {
            _AccessTokenRepository = AccessTokenRepository;
        }

        public Task<AccessToken> AddAccessToken(AccessToken AccessToken)
        {

            return _AccessTokenRepository.AddAsync(AccessToken);
        }
        public async Task UpdateAccessToken(AccessToken AccessToken)
        {

            await _AccessTokenRepository.UpdateAsync(AccessToken);
        }
        public async Task<AccessToken> GetActiveAccessToken(long userId)
        {
            return _AccessTokenRepository.Where(ac => ac.UserId== userId && ac.Status == 1).FirstOrDefault();
        }

        //Task<AccessToken> IAccessTokenRepository.GetActiveAccessToken(long userID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
