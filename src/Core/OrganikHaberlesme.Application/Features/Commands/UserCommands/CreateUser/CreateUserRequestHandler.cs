using MediatR;
using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;
using OrganikHaberlesme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserReadRepository _readRepo;
        private readonly IUserWriteRepository _writeRepo;

        public CreateUserRequestHandler(IUserReadRepository readRepo, IUserWriteRepository writeRepo)
        {
            _readRepo = readRepo;
            _writeRepo = writeRepo;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<User, bool>> condition = (u => u.PhoneNumber == request.PhoneNumber || u.Email == request.Email  ||u.Name==request.Name);

            if(await _readRepo.IsExistAsync(condition) == false)
            {
                User u = new()
                {
                    PhoneNumber = request.PhoneNumber,
                    CreatedDate = DateTime.UtcNow,
                    Email = request.Email,
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Password = request.Password,
                    TwoFactor = request.TwoFactor,
                };
                var result = await _writeRepo.AddAsync(u);
                return new CreateUserResponse { IsSuccess = result };
            }
            return new CreateUserResponse { IsSuccess = false };
        }
    }
}
