using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Domain.Entities;

public class UserCredentials
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } = default!;
    public byte[] HashedPassword { get; set; } = default!;
}
