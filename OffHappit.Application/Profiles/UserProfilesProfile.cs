using AutoMapper;
using OffHappit.Application.Features.Authentication.Commands.Registeration;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Profiles;

public class UserProfilesProfile : Profile
{
    public UserProfilesProfile()
    {
        CreateMap<UserProfile, RegisterUserRequest>().ReverseMap();
    }
}
