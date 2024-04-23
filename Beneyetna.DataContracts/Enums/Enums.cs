using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Enums
{
    public enum EStatus
    {
        Active = 1,
        Inactive = 0
    }
    public enum EAccessTokenStatus
    {
        Verified = 1,
        NotVerified = 0
    }
    public enum ELoginByType
    {
        Gmail = 0,
        Email = 1,
        Facebook = 2
    }
}
