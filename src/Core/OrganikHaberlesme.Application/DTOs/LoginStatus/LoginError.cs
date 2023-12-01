using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.DTOs.LoginStatus
{
    public class LoginError : LoginUserResponse
    {
        public string Message { get; set; } = "error";
    }
}
