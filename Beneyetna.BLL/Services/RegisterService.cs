using Beneyetna.BLL.IServices;
using Beneyetna.DAL;
using Beneyetna.DataContracts.Context;
using Beneyetna.DataContracts.DTO;
using Beneyetna.DataContracts.Entities;
using Beneyetna.DataContracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Utilities.Notification;

namespace Beneyetna.BLL.Services
{
    public class RegisterService : IRegisterService
    {
        DALFacade _dALFacade;
        private AppSettings _appSettings { set; get; }
        public IConfiguration _configuration { get; set; }
        private readonly ILogger _logger;

        public RegisterService(DALFacade dALFacade, IConfiguration configuration, ILogger<RegisterService> logger)
        {
            _dALFacade = dALFacade;
            _configuration = configuration;
            _appSettings = _configuration.Get<AppSettings>();
            _logger = logger;
        }
        public async Task<ApiResponse> RegisterByEmail(RegisterDTO registerDTO, string AuthorizationDtoString)
        {

            _logger.LogInformation("Start RegisterDto");
            #region check the authorization 
            //
            //string AuthorizationDtoString = "{\r\n  \"AppId\": \"your_app_id\",\r\n  \"AppSecret\": \"your_app_secret\",\r\n  \"DeviceToken\": \"your_device_token\",\r\n  \"Token\": \"your_token\"\r\n}";
            AuthorizationDto authorization = JsonConvert.DeserializeObject<AuthorizationDto>(AuthorizationDtoString);
            if (authorization!=null && !authorization.IsAuthenticated(_appSettings.AppId,_appSettings.AppSecret,false,true))
            {
                _logger.LogWarning($"Warning Bad Request");
                return new ApiResponse("Bad Request !", StatusCodes.Status400BadRequest, string.Empty, 0);
            }

            #endregion


            User user = await _dALFacade._userRepository.GetUserByEmail(registerDTO.email);
            bool isNewUser = user == null;

            if (user == null)
            {
                user = new User();
                user.Email = registerDTO.email;
                user.Name = registerDTO.name;
            }

            AccessToken accessToken = new AccessToken();
            accessToken = accessToken.SetStaticValues(accessToken, -1, "registerDTO.DeviceToken");
            accessToken.DevicePlatform = registerDTO.DevicePlatform;


            using (var transaction = _dALFacade._context.Database.BeginTransaction())
            {

                if (isNewUser)
                {
                    user = await _dALFacade._userRepository.AddUser(user);
                }

                accessToken.UserId = user.Id;

                if (!isNewUser)
                {
                    AccessToken oldAccessToken = await _dALFacade._accessTokenRepository.GetActiveAccessToken(user.Id);
                    if (oldAccessToken !=null)
                    {
                        oldAccessToken.Status = -1;
                        _dALFacade._accessTokenRepository.UpdateAccessToken(oldAccessToken); 
                    }
                }
                _dALFacade._accessTokenRepository.AddAccessToken(accessToken);
                transaction.Commit();
            }

            string emailTemplate = File.ReadAllText(_appSettings.EmailConfiguration.VerifyCodeByEmailTemplate);
            Utilities.Notification.Email.EmailConfiguration _em = new Utilities.Notification.Email.EmailConfiguration
            {
                SmtpServer = _appSettings.EmailConfiguration.SmtpServer,
                SmtpPort = _appSettings.EmailConfiguration.SmtpPort,
                SmtpUsername = _appSettings.EmailConfiguration.SmtpUsername,
                SmtpPassword = _appSettings.EmailConfiguration.SmtpPassword,
                DisplayName = _appSettings.EmailConfiguration.DisplayName,
            };
            emailTemplate = emailTemplate.Replace("$verification_code", accessToken.VerificationCode);
            Notification notification = new Notification(_em);
            notification.SendEmail(registerDTO.email, emailTemplate);

            return new ApiResponse(null, StatusCodes.Status200OK, new { Token = accessToken.Token }, 1);

        }

        
    }
}
