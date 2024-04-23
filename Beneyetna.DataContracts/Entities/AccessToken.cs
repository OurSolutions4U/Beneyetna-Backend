using Beneyetna.DataContracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Entities
{
    [Table("AccessToken")]
    public class AccessToken : BaseEntity
    {
        public long UserId { get; set; }
        public string? Token { set; get; }
        public string? DeviceToken { set; get; }
        public DateTime? ExpiryDate { set; get; }
        public int LoginBy { get; set; } = (int) ELoginByType.Email;
        public int NumberOfAttempts {  get; set; }
        public int VerificationStatus { get; set; } = (int) EAccessTokenStatus.NotVerified;
        public string? VerificationCode { set; get; }
        public string? DevicePlatform { set; get; }
        public DateTime? VerificationCodeExpiryDate { set; get; }
        public DateTime? VerifiedAt { set; get; }
        public AccessToken SetStaticValues(AccessToken accessToken, int loginBy, string deviceToken)
        {

            accessToken.Token = GenerateAccessTokenWithoutHash();
            accessToken.DeviceToken = deviceToken;
            accessToken.VerificationCode = GenerateVerificationToken();

            //if (loginBy == enSignUpTypes.EMAIL || loginBy == enSignUpTypes.PHONE_NUMBER)
            //{
            //    accessToken.verification_code = Security.GenerateVerificationToken();
            //}
            accessToken.ExpiryDate = null;
            accessToken.VerificationCodeExpiryDate = null;
            accessToken.VerifiedAt = null;
            return accessToken;
        }
        public static string GenerateVerificationToken()
        {
            try
            {
                Random generator = new Random();
                return generator.Next(0, 99999).ToString("D5");
            }
            catch (Exception ex)
            {
                //_logger.Error(ex.Message, ex);
                return null;
            }
        }

        public static string GenerateAccessTokenWithoutHash()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string token = new string(Enumerable.Repeat(chars, 64)
              .Select(s => s[new Random().Next(s.Length)]).ToArray());
            return token;
        }

    }

}
