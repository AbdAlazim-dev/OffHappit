using Microsoft.EntityFrameworkCore;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence.DbContexts
{
    public class OffHappitsDbContext : DbContext
    {
        public OffHappitsDbContext(DbContextOptions<OffHappitsDbContext> options) : base(options)
        {
        }
        public DbSet<UserCredentials> UsersCredentials { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OffHappitsDbContext).Assembly);
        }
    }
}
