using MediatR;
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

        public LoginUserRequestHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            if (await _userReadRepository.IsExistAsync(u=>u.Name == request.UserName && u.Password == request.Password))
            {
                return new LoginUserResponse { OtpController = Guid.NewGuid() };
            }
            return default;
        }
    }
}
