using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OffHappit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence.Configurations;

public class UserCredentialsConfiguration : IEntityTypeConfiguration<UserCredentials>
{
    public void Configure(EntityTypeBuilder<UserCredentials> builder)
    {
        builder.Property(u => u.PasswordSalt)
            .IsRequired()
            .HasColumnType("BLOB");
        builder.Property(u => u.HashedPassword)
            .IsRequired()
            .HasColumnType("BLOB");

        builder.HasKey(u => u.UserId);
    }
}

