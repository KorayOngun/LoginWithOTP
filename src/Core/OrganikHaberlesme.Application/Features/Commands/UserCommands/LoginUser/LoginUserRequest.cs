﻿using MediatR;
using OrganikHaberlesme.Application.DTOs.LoginStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
