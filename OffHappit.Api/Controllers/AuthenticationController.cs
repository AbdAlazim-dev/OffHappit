using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        //public ActionResult<string> Login()
        //{
        //    return "Hello World";
        //}
        [HttpPost("register")]
        public ActionResult<Guid> Register(RegisterUserRequest request)
        {
            var userId = _mediator.Send(request);
            return Ok(userId);
        }
    }
}
