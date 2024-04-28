using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Services;

public interface IAuthServices
{
    public byte[] CreateSalt();
    public byte[] HashPassword(string password, byte[] salt);
}
