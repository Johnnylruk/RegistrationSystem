using System.Security.Cryptography;
using System.Text;

namespace RegistrationSystem.UI.Helper
{
    public static class Criptography
    {
        public static string GenerateHash(this string hash)
        {
            var CreateHash = SHA256.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(hash);

            array = CreateHash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }
    }
}
