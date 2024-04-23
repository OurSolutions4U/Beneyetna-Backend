using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.Notification.Email;

namespace Utilities.Notification
{
    public class Notification
    {

        private static EmailConfiguration _emailConfiguration;
        //private static FirebaseApp defaultApp;
        public Notification(EmailConfiguration emailConfiguration)
        {
            //var configurationBuilder = new ConfigurationBuilder()
            //        .SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //_emailConfiguration = new EmailConfiguration()
            //{
            //    SmtpServer = configurationBuilder.GetSection("EmailConfiguration:SmtpServer").Value,
            //    SmtpPort = int.Parse(configurationBuilder.GetSection("EmailConfiguration:SmtpPort").Value),
            //    SmtpUsername = configurationBuilder.GetSection("EmailConfiguration:SmtpUsername").Value,
            //    SmtpPassword = configurationBuilder.GetSection("EmailConfiguration:SmtpPassword").Value,
            //    DisplayName = configurationBuilder.GetSection("EmailConfiguration:DisplayName").Value
            //};
            _emailConfiguration = emailConfiguration;
        }

        public async void SendEmail(string email, string content)
        {
            try
            {
                var message = new EmailMessage
                {
                    ToAddress = new EmailAddress(email),
                    Subject = "Verify Email",
                    Content = content
                };

                SendAsync(message);
            }
            catch (Exception ex)
            {
                //_logger.Error(ex.Message, ex);
            }
        }


        public async static void SendAsync(EmailMessage emailMessage)
        {
            try
            {
                using (var emailClient = new SmtpClient(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort))
                {
                    emailClient.UseDefaultCredentials = false;
                    emailClient.Credentials = new NetworkCredential(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    emailClient.EnableSsl = true;
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(_emailConfiguration.SmtpUsername, _emailConfiguration.DisplayName),
                    };
                    //mailMessage.To.Add(emailMessage.ToAddress);
                    mailMessage.To.Add(emailMessage.ToAddress);

                    mailMessage.Subject = emailMessage.Subject;
                    mailMessage.Body = emailMessage.Content;
                    mailMessage.IsBodyHtml = true;

                    await emailClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {

            }
        }

        //public async static Task<string> SendNotification(string deviceToken, string title, string body)
        //{
        //    var message = new Message()
        //    {
        //        Notification = new FirebaseAdmin.Messaging.Notification()
        //        {
        //            Title = title,
        //            Body = body

        //        },
        //        Token = deviceToken,
        //    };
        //    if (FirebaseMessaging.DefaultInstance == null)
        //    {
        //        defaultApp = FirebaseApp.Create(new AppOptions()
        //        {
        //            Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "firebase.json")),
        //        });
        //    }
        //    string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        //    return response;
        //}

    }
}
