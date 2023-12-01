using MediatR;
using OrganikHaberlesme.Application.DTOs;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using OrganikHaberlesme.Application.Interfaces.LoginClaim;
using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ILoginClaimServices _loginClaimServices;
        public LoginUserRequestHandler(IUserReadRepository userReadRepository, ILoginClaimServices loginClaimServices)
        {
            _userReadRepository = userReadRepository;
            _loginClaimServices = loginClaimServices;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            if (await _userReadRepository.IsExistAsync(u=>u.Name == request.UserName && u.Password == request.Password))
            {
                if ((await _userReadRepository.GetByUserName(request.UserName)).TwoFactor == true)
                {
                    var otpController = Guid.NewGuid();

                    var user = (await _userReadRepository.GetByUserName(request.UserName));

                    await _loginClaimServices.CreateLoginClaimAsync(otpController, new() { Email = user.Email, PhoneNumber = user.PhoneNumber });

                    return new TwoFactorWaiting { OtpController = otpController, Status = Enums.LoginStatus.TwoFactorWaiting };
                }
                return new LoginSuccess { Token =" al sana token", Status = Enums.LoginStatus.Success };
              
            }
            return new LoginError {Message = "hata hata hata",Status = Enums.LoginStatus.Error };
        }
    }
}
