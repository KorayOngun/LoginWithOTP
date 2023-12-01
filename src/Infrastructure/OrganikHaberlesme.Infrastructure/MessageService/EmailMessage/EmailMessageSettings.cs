using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Infrastructure.MessageService.EmailMessage
{
    public class EmailMessageSettings
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string SmtpClient {  get; set; }
        public bool EnableSsl { get; set; }
        public string Host {  get; set; }
    }
}
