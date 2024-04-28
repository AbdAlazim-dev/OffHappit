using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Contracts;

public interface IProfileRepository : IAsyncRepository<UserProfile>
{
    Task<bool> UserExists(string email);
}
