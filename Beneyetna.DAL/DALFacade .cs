using Beneyetna.DAL.Interfaces;
using Beneyetna.DAL.Repositories;
using Beneyetna.DataContracts.Context;

namespace Beneyetna.DAL
{
    public class DALFacade
    {


        public readonly IUserRepository _userRepository;
        public readonly IAccessTokenRepository _accessTokenRepository;
        public readonly BeneyetnaContext _context;

        public DALFacade(IUserRepository userRepository, IAccessTokenRepository accessTokenRepository, BeneyetnaContext context)
        {
            _userRepository = userRepository;
            _accessTokenRepository = accessTokenRepository;
            _context = context;
        }

        //BeneyetnaContext _context;

        //public BeneyetnaContext Context
        //{
        //    get
        //    {
        //        return _context;
        //    }
        //}

        //public DALFacade(BeneyetnaContext context)
        //{
        //    _context = context;
        //}
        //public IUserRepository UserRepository
        //{
        //    get
        //    {
        //        return new UserRepository(_context);
        //    }
        //    //Issa
        //}
    }
}
