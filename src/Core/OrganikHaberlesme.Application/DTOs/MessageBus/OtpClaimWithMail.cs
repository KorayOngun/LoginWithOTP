using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.DTOs.MessageBus
{
    public class OtpClaimWithMail
    {
        public string EMail { get; set; }
        public int Otp { get; set; }
    }
}
