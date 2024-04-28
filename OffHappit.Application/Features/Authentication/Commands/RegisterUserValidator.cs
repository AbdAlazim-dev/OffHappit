using FluentValidation;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        private readonly IAuthenticateRepository _authRepository;
        public RegisterUserValidator()
        {

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} is not a valid email address.");

            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(6).WithMessage("{PropertyName} must be at least 6 characters.");

            RuleFor(p => p.PasswordConfirm)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Equal(p => p.Password).WithMessage("The two password you entered dose not must.");
            RuleFor(p => p.Email)
                .MustAsync(BeUniqueEmail).WithMessage("{PropertyName} is already in use.");
                
        }
        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return (!await _authRepository.UserExists(email));
        }
    }
}
