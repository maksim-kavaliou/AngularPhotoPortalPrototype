using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using PhotoPortal.Services.Interfaces.Services;

namespace PhotoPortal.Services.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptUserCredantials(string email, string password)
        {
            var data = $"{email.Trim().ToLowerInvariant()}_{password}";

            return Encrypt(data);
        }

        public string Encrypt(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);

            var hash = new SHA512Managed().ComputeHash(bytes);

            var result = Convert.ToBase64String(hash);

            return result;
        }
    }
}