using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands.Login
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
