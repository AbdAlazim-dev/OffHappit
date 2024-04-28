using AutoMapper;
using OffHappit.Application.Features.Authentication.Commands;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Profiles;

public class UserAuthProfile : Profile
{
    public UserAuthProfile()
    {
        CreateMap<UserCredentials, RegisterUserRequest>().ReverseMap();
    }
}
