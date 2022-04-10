using SodaCompany.Application.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SodaCompany.Application.Services
{
    public class HashingService : IHashingService
    {
        public bool CompareHash(string hash, string comparedHash)
        {
            return string.Equals(hash, comparedHash);
        }

        public string ComputeHash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
