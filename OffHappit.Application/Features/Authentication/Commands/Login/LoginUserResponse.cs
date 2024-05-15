using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffHappit.Application.Features.Authentication.Dtos;
using OffHappit.Application.Responses;

namespace OffHappit.Application.Features.Authentication.Commands.Login;

public class LoginUserResponse : BaseResponse
{
    public LoginUserResponse() : base()
    {
    }
    public UserDto User { get; set; }
}
