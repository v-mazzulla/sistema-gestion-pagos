using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Utilidades
{
    public class Crypto
    {
        public static string HashPasswordConBCrypt(string passwordOriginal)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword(passwordOriginal);
            return hash;
        }

        public static bool VerificarPasswordConBCrypt(string passwordOriginal, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(passwordOriginal, passwordHash);
        }
    }
}
