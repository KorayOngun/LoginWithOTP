﻿using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required]
        [MinLength(3),MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
    }
}
