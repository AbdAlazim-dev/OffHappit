using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands.Registeration;

public class RegisterUserRequest : IRequest<Guid>
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? City { get; set; }
    public string? Password { get; set; }
    public string? PasswordConfirm { get; set; }
}

