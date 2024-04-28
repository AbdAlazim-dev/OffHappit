using Microsoft.EntityFrameworkCore;
using OffHappit.Application.Contracts;
using OffHappit.Domain.Entities;
using OffHappit.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence.Repositories
{
    public class AuthenticateRerpository : BassRepository<UserCredentials>, IAuthenticateRepository
    {
        
        public AuthenticateRerpository(OffHappitsDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> UserExists(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }

}
