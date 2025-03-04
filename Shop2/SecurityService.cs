using System.Security.Cryptography;
using System.Text;

namespace Shop2;

public static class SecurityService
{
    public static string Hash(this string hash)
    {
        var sha512 = new SHA512Managed();
        var bytes=Encoding.UTF8.GetBytes(hash);
        var hashedBytes = sha512.ComputeHash(bytes);
        var hashedString = Encoding.UTF8.GetString(hashedBytes);
        return hashedString;
    }
}