using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LAC.Classes
{
    internal class Encryption
    {
        private static string _encryptionKey = Properties.Settings.Default.Key;

        public static string Encrypt(string plainText)
        {
            var clearBytes = Encoding.Unicode.GetBytes(plainText);
            byte[] encryptedBytes;

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(_encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes;

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(_encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return Encoding.Unicode.GetString(decryptedBytes);
        }
    }
}