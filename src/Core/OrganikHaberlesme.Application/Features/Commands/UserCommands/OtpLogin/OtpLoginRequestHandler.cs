using MediatR;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.OtpLogin
{
    public class OtpLoginRequestHandler : IRequestHandler<OtpLoginRequest, LoginUserResponse>
    {
        private readonly ILoginClaimServices _loginClaimServices;

        public OtpLoginRequestHandler(ILoginClaimServices loginClaimServices)
        {
            _loginClaimServices = loginClaimServices;
        }

        public async Task<LoginUserResponse> Handle(OtpLoginRequest request, CancellationToken cancellationToken)
        {
            if(await _loginClaimServices.OtpCheck(request.OtpController, request.Otp))
            {
                //TODO 01: Burayı düzeltmeyi unutma !!!
                return new LoginSuccess() { Token = "giriş başarılı TOKEN => 1234546435745754532412", Status = Enums.LoginStatus.Success};
            }
            return new LoginError { Message = "hata hata hata", Status = Enums.LoginStatus.Error };
        }
    }
}
