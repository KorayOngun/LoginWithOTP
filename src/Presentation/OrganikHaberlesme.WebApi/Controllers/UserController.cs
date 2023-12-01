using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganikHaberlesme.Application.Features.Commands.UserCommands.CreateUser;
using OrganikHaberlesme.Application.Features.Commands.UserCommands.LoginUser;
using OrganikHaberlesme.Application.Interfaces.Repositories.UserRepo;

namespace OrganikHaberlesme.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
