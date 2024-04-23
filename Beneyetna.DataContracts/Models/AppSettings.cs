using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Models
{
    public class AppSettings
    {
        public string AppSecret { set; get; } = string.Empty;
        public string AppId { set; get; } = string.Empty;
        public EmailConfiguration? EmailConfiguration { set; get; }

    }

    public class EmailConfiguration
    {
        public string SmtpServer { set; get; } = string.Empty;
        public int SmtpPort { set; get; }

        public string SmtpUsername { set; get; } = string.Empty;
        public string SmtpPassword { set; get; } = string.Empty;
        public string DisplayName { set; get; } = string.Empty;
        public string VerifyCodeByEmailTemplate { set; get; } = string.Empty;
    }
}
