using System.Security.Cryptography;
using System.Text;

namespace SAST_Demo.Services
{
    public class WeakCryptoService
    {
        public string HashPassword(string password)
        {
            // ❌ MD5 hashing pattern SAST will detect
            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = md5.ComputeHash(bytes);

            return Convert.ToHexString(hash);
        }

         public string HashPassword2(string password)
        {
            // ❌ MD5 hashing pattern SAST will detect
            password ="Passw0rd";
            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = md5.ComputeHash(bytes);

            return Convert.ToHexString(hash);
        }
    }
}
