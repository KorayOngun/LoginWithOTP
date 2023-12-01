using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganikHaberlesme.Application.Features.Commands.UserCommands.CreateUser;
using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;

namespace OrganikHaberlesme.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMediator _mediator;
        public UserController(IUserReadRepository userReadRepository, IMediator mediator)
        {
            _userReadRepository = userReadRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
