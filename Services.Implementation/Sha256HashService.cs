using Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Services.Implementation
{
    public sealed class Sha256HashService : IHashService
    {
        public string ComputeHash(string text)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
