using Beneyetna.DataContracts.DTO;
using Beneyetna.DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Beneyetna.BLL.IServices
{
    public interface IRegisterService
    {
        public Task<ApiResponse> RegisterByEmail(RegisterDTO registerDTO,string authenticationStr);
    }
}
