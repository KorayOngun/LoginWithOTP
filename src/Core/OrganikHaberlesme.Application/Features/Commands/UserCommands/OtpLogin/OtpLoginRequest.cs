using MediatR;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.OtpLogin
{
    public class OtpLoginRequest : IRequest<LoginUserResponse>
    {
        public int Otp { get; set; }
        public Guid OtpController { get; set; }
    }
}
