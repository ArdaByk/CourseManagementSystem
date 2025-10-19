using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Common.Security.Hashing;

using System.Security.Cryptography;
using System.Linq;

public static class HashingHelper
{
    public static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        passwordSalt = RandomNumberGenerator.GetBytes(16);

        var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, 100000, HashAlgorithmName.SHA256);
        passwordHash = pbkdf2.GetBytes(32);
    }

    public static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100000, HashAlgorithmName.SHA256);
        byte[] computedHash = pbkdf2.GetBytes(32);

        return computedHash.SequenceEqual(storedHash);
    }
}

