using OffHappit.Application.Features.Authentication.Commands.Login;
using OffHappit.Application.Features.Authentication.Dtos;
using OffHappit.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Features.Authentication.Commands.Registeration;

public class RegisterUserResponse : BaseResponse
{
    public RegisterUserResponse() : base()
    {
    }

    public UserDto User { get; set; }
}
