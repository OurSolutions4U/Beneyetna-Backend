using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.DTO
{
    public class AuthorizationDto
    {
        public string AppId { get; set; } = string.Empty;
        public string AppSecret { get; set; } = string.Empty;
        public string DeviceToken { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public bool IsAuthenticated(string? defaultAppId, string? defaultAppSecret, bool isByPassDeviceToken, bool isByPassToken)
        {
            if (string.IsNullOrEmpty(AppId) || !AppId.Equals(defaultAppId))
            {
                return false;
            }

            if (string.IsNullOrEmpty(AppSecret) || !AppSecret.Equals(defaultAppSecret))
            {
                return false;
            }

            if (!isByPassDeviceToken && string.IsNullOrEmpty(DeviceToken))
            {
                return false;
            }
            if (!isByPassToken && string.IsNullOrEmpty(Token))
            {
                return false;
            }
            return true;
        }
    }
}
