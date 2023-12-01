using OrganikHaberlesme.Application.DTOs;
using OrganikHaberlesme.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.LoginClaim
{
    public interface ILoginClaimServices
    {
        Task CreateLoginClaimAsync(Guid OtpController,LoginClaimUserData userData);
        Task SendOtpAsync(Guid OtpController,OtpSendMethod sendMethod);
        Task<bool> OtpCheck(Guid otpController,int otp);
    }
}
