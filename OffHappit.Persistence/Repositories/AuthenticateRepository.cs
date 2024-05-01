using Microsoft.EntityFrameworkCore;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using OffHappit.Domain.Entities;
using OffHappit.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence.Repositories
{
    public class AuthenticateRepository : BassRepository<UserCredentials>, IAuthenticateRepository
    {
        private readonly IAuthServices _authServices;


        public AuthenticateRepository(OffHappitsDbContext dbContext,
            IAuthServices authServices) : base(dbContext)
        {
            _authServices = authServices;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _dbContext.UsersCredentials.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> ValidateUser(string email, string password)
        {
            //get the password salt from the database
            var user = await _dbContext.UsersCredentials.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;
            //hash the password with the salt
            var hashedPassword = _authServices.HashPassword(password, user.PasswordSalt);
            return await _dbContext.UsersCredentials.AnyAsync(u => u.Email == email && u.HashedPassword == hashedPassword);
        }
    }

}
