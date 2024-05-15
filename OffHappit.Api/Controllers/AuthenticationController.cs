using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OffHappit.Application.Features.Authentication.Commands.Login;
using OffHappit.Application.Features.Authentication.Commands.Registeration;
using OffHappit.Exceptions;
using OffHappit.Api.Services;
using System.Net;

namespace OffHappit.Api.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
        private readonly ITokenServices _tokenServices;
        public AuthenticationController(IMediator mediator,
            ProblemDetailsFactory problemDetailsFactory,
            ITokenServices tokenServices)
        {
            _mediator = mediator;
            _problemDetailsFactory = problemDetailsFactory;
            _tokenServices = tokenServices;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            var userProfile = new LoginUserResponse();
            try
            {
                userProfile = await _mediator.Send(request);
            }
            catch (ValidationException ex)
            {
                userProfile.ValidationErrors = ex.ValidationErrors;

                return BadRequest(_problemDetailsFactory.CreateProblemDetails(
                    HttpContext,
                    title: "Validation Error",
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: userProfile.ValidationErrors[0]));
            }
            return Ok(_tokenServices.GenerateJwtToken(userProfile.User));
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserRequest request)
        {
            var userResponse = new RegisterUserResponse(); 
            try
            {
                userResponse = await _mediator.Send(request);
            }
            catch (ValidationException ex)
            {
                userResponse.ValidationErrors = ex.ValidationErrors;
                return BadRequest(_problemDetailsFactory.CreateProblemDetails(
                    HttpContext,
                    title: "Validation Error",
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: userResponse.ValidationErrors[0]));
            }

            return Ok(userResponse.User); 
        }
    }
}
