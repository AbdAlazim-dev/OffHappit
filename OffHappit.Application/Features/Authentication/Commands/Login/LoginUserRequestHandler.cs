using MediatR;
using OffHappit.Application.Contracts;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands.Login;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IAuthenticateRepository _authRpository;
    private readonly IAsyncRepository<UserProfile> _profileRepository;
    public LoginUserRequestHandler(IAuthenticateRepository authRpository,
        IAsyncRepository<UserProfile> _userProfile)
    {
        _authRpository = authRpository;
        _profileRepository = _userProfile;
    }
    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var LoginUserResponse = new LoginUserResponse();
        var userRequestValidator = new LoginUserRequestValidator(_authRpository);
        var validationResult = await userRequestValidator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
        {
            LoginUserResponse.Success = false;
            LoginUserResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                LoginUserResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }
        if (LoginUserResponse.Success)
        {
            var userId = await _authRpository.GetUserId(request.Email);
            var user = await _profileRepository.GetByIdAsync(userId);


            LoginUserResponse.User = new UserDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City
            };
            
        }
        return LoginUserResponse;

    }
}

