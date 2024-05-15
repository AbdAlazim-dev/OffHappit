using OffHappit.Application.Features.Authentication.Dtos;

namespace OffHappit.Api.Services;

public interface ITokenServices
{
    string GenerateJwtToken(UserDto user);
}