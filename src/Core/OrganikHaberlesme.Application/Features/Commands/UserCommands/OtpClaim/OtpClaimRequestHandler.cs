using MediatR;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using OrganikHaberlesme.Application.Features.Commands.UserCommands.LoginUser;
using OrganikHaberlesme.Application.Features.Commands.UserCommands.OtpLogin;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.OtpClaim
{
    public class OtpClaimRequestHandler : IRequestHandler<OtpClaimRequest, LoginUserResponse>
    {
        private readonly ILoginClaimServices _loginClaimServices;

        public OtpClaimRequestHandler(ILoginClaimServices loginClaimServices)
        {
            _loginClaimServices = loginClaimServices;
        }

        public async Task<LoginUserResponse> Handle(OtpClaimRequest request, CancellationToken cancellationToken)
        {
           await _loginClaimServices.SendOtpAsync(request.OtpController,request.SendMethod);
           return new TwoFactorWaiting {OtpController=request.OtpController ,Status=Enums.LoginStatus.TwoFactorWaiting };
        }
    }
}
