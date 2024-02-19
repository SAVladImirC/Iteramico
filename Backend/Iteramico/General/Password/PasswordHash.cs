using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace General.Password
{
    public class PasswordHash
    {
        public static (string passwordHash, byte[] salt) GeneratePasswordHash(string password, byte[]? salt = null)
        {
            try
            {
                salt ??= RandomNumberGenerator.GetBytes(128 / 8);

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8
                    ));
                return (hashed, salt);
            }
            catch (Exception e)
            {
                //TODO
                return ("", []);
            }
        }

        public static bool ValidatePasswordHash(string originalPassword, string passwordHash, byte[] passwordSalt)
        {
            try
            {
                return GeneratePasswordHash(originalPassword, passwordSalt).passwordHash == passwordHash;
            }
            catch (Exception ex)
            {
                // TODO: Exception Handling
                return false;
            }
        }
    }
}