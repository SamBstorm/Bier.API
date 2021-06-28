using System;
using System.Security.Cryptography;
using System.Text;

namespace Tools
{
    public class PasswordHasher
    {
        public static string Hashing<T>(T userModel, Func<T, string> passwordSelector, Func<T, string> saltSelector)
        {
            string password = passwordSelector(userModel);
            string salt = saltSelector(userModel);
            string result = salt.Substring(0, salt.Length / 2) + password + salt.Substring(salt.Length / 2);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(result));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
