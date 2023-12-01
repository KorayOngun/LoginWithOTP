using OrganikHaberlesme.Application.DTOs;
using OrganikHaberlesme.Application.Enums;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using OrganikHaberlesme.Application.Interfaces.Messages;
using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrganikHaberlesme.LoginClaim
{
    public class LoginClaimService : ILoginClaimServices
    {
        private readonly ILoginClaimRepo _loginClaimRepo;
        private readonly IEmailMessageService _emailMessageService;
        public LoginClaimService(ILoginClaimRepo loginClaimRepo, IEmailMessageService emailMessageService)
        {
            _loginClaimRepo = loginClaimRepo;
            _emailMessageService = emailMessageService;
        }

        public async Task CreateLoginClaimAsync(Guid OtpController, LoginClaimUserData userData)
        {
            var serializeData = JsonSerializer.Serialize(userData);
            await _loginClaimRepo.SetAsync(OtpController.ToString(), serializeData);
        }

        public async Task<bool> OtpCheck(Guid otpController, int otp)
        {
            return  (await _loginClaimRepo.GetAsync(otpController.ToString())) == otp.ToString();
        }

        public async Task SendOtpAsync(Guid OtpController, OtpSendMethod sendMethod)
        {
            var otp = new Random().Next(100000,999999);
            var jsonData = await _loginClaimRepo.GetAsync(OtpController.ToString());
            var userData = JsonSerializer.Deserialize<LoginClaimUserData>(jsonData);
            await _loginClaimRepo.SetAsync(OtpController.ToString(), otp.ToString());
            switch (sendMethod)
            {
                case OtpSendMethod.Mail:
                    _emailMessageService.Send(userData.Email, otp.ToString());
                    break;
                case OtpSendMethod.Sms:
                    break;
            }
        }
    }
}
