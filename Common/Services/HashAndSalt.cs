using System.Security.Cryptography;

namespace PocketA3.Common.Services
{
    public class HashAndSalt
    {


        static public String HashInput(string input, byte[] salt) {
      

         

            // Hash the password along with the salt
            byte[] hashedPassword = HashPassword(input, salt);

            // Convert the salt and hashed password to Base64 strings for storage
            string saltString = Convert.ToBase64String(salt);
            return Convert.ToBase64String(hashedPassword);

        }
        static public byte[] GenerateSalt()
        {
            byte[] salt = new byte[32]; // 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        static private byte[] HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // 256 bits
            }
        }
    }
}
