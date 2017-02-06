using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoPortal.Services.Interfaces.Services
{
    public interface IEncryptionService
    {
        string EncryptUserCredantials(string email, string password);

        string Encrypt(string data);
    }
}
