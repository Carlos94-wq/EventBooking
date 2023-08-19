using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.CustomEntities
{
    public class EmailSettings
    {
        public string FromEmail{ get; set; }
        public string SmtpUsername{ get; set; }
        public string SmtpPassword{ get; set; }
        public int SmtpPort{ get; set; }
        public string SmtpServer { get; set; }
    }
}
