using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application.Services;

public class AuthServices : IAuthServices
{
    private readonly IConfiguration _configuration;
    public AuthServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public byte[] CreateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    public byte[] HashPassword(string password, byte[] salt)
    {
        string? secretKey = _configuration["AppSettings:SecretKey"];

        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            Array.Copy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Array.Copy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            byte[] hashedPassword = hmac.ComputeHash(combinedBytes);
            return hashedPassword;
        }
    }
}
