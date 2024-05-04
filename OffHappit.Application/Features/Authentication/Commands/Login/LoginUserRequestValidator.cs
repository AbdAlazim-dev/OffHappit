using FluentValidation;
using OffHappit.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands.Login;

public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
{
    private readonly IAuthenticateRepository _authRepository;
    public LoginUserRequestValidator(IAuthenticateRepository authenticateRepository)
    {
        _authRepository = authenticateRepository;
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();

        RuleFor(p => p)
            .MustAsync(BeValidUser).WithMessage("Invalid email or password.");
    }
    public async Task<bool> BeValidUser(LoginUserRequest request, CancellationToken cancellationToken)
    {
        return await _authRepository.ValidateUser(request.Email, request.Password);
    }

}
