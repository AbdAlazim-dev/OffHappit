using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Contracts;

public interface IAuthenticateRepository : IAsyncRepository<UserCredentials>
{
    Task<bool> ValidateUser(string email, string password);
    Task<bool> UserExists(string email);
}
