using MediatR;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using OrganikHaberlesme.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.OtpLogin
{
    public class OtpClaimRequest : IRequest<LoginUserResponse>
    {
        public Guid OtpController { get; set; }
        public OtpSendMethod SendMethod { get; set; }
    }
}
