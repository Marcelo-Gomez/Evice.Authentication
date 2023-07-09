using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Evice.Authentication.Infrastructure.Services
{
    public static class EncryptionService
    {
        public static string GetHashedPassword(string password)
        {
            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            var salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
 
            // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }
    }
}