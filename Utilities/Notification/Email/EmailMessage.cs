using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Notification.Email
{
    public class EmailMessage
    {
        public EmailAddress ToAddress { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string DisplayName { get; set; }
    }
}
