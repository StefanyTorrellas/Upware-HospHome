using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VetPet.App.Persistencia
{
    public class Encrypt
    {
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = null;
            StringBuilder sb = new StringBuilder();
            data = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < data.Length; i++) sb.AppendFormat("{0:x2}", data[i]);
            return sb.ToString();
        }
    }
}