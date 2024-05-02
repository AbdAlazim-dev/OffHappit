using MediatR;
using Microsoft.AspNetCore.Mvc;
using OffHappit.Application.Features.Authentication.Commands.Login;
using OffHappit.Application.Features.Authentication.Commands.Registeration;

namespace OffHappit.Api.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            var userProfile = await (_mediator.Send(request));
            return Ok(userProfile);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            var user = await _mediator.Send(request);
            return Ok(user);
        }
    }
}
