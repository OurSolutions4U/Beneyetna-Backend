using Beneyetna.BLL.IServices;
using Beneyetna.BLL.Services;
using Beneyetna.DAL;
using Beneyetna.DataContracts.Context;

namespace Beneyetna.BLL
{
    public class BLLFacade
    {
        public readonly IRegisterService _registerService;

        public BLLFacade(IRegisterService registerService)
        {
            _registerService = registerService;
        }
    }
}
