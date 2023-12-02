using Hangfire;
using OrganikHaberlesme.Application.DTOs;
using OrganikHaberlesme.Application.Enums;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using OrganikHaberlesme.Application.Interfaces.Messages;
using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // Creates request before receiving one-time password
        public async Task CreateLoginClaimAsync(Guid OtpController, LoginClaimUserData userData)
        {
            var serializeData = JsonSerializer.Serialize(userData);
            await _loginClaimRepo.SetAsync(OtpController.ToString(), serializeData);
        }

        //Checks the entered one-time password
        public async Task<bool> OtpCheck(Guid otpController, int otp)
        {
            var result =  (await _loginClaimRepo.GetAsync(otpController.ToString())) == otp.ToString();

            if (result)
            {
                await _loginClaimRepo.DeleteAsync(otpController.ToString());
            }

            return result;
        }

        // Sends one-time password with selected method
        public async Task SendOtpAsync(Guid OtpController, OtpSendMethod sendMethod)
        {
            var otp = new Random().Next(100000,999999);
            var jsonData = await _loginClaimRepo.GetAsync(OtpController.ToString());
            var userData = JsonSerializer.Deserialize<LoginClaimUserData>(jsonData);
            await _loginClaimRepo.SetAsync(OtpController.ToString(), otp.ToString());
            
            switch (sendMethod)
            {
                case OtpSendMethod.Mail:
                    _emailMessageService.SendAddQueue(userData.Email, otp.ToString());
                    break; 
                case OtpSendMethod.Sms:
                    break;
            }
        }
    }
}
