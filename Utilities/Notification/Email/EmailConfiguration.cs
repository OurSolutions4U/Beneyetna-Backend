﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Notification.Email
{
    public class EmailConfiguration
    {
        public string SmtpServer { get; set; } =string.Empty;
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; } = string.Empty;
        public string SmtpPassword { get; set; } = string.Empty;
        public string DisplayName { set; get; } = string.Empty;
    }
}
