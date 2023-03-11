using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17844
{
    internal class CBC
    {
        //CBC-A4

        private string encrStr;
        readonly byte[] k;

        public void Set(string s)
        {
            this.encrStr = s;
        }

        public string Get()
        {
            return this.encrStr;
        }

        public CBC(string base_64_key)
        {
            this.k = Convert.FromBase64String(base_64_key);
        }

        public static string GenerateIV()
        {
            var rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.GenerateIV();
            return Convert.ToBase64String(rijndaelManaged.IV);
        }

        //Encrypt metoda
        public string Encrypt(string plainString, string base64IV)
        {
            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                Key = k,
                IV = Convert.FromBase64String(base64IV),
            };
            var encr = rijndael.CreateEncryptor();
            byte[] b = Encoding.UTF8.GetBytes(plainString);
            return Convert.ToBase64String(encr.TransformFinalBlock(b, 0, b.Length));
        }

        //Decrypt metoda
        public string Decrypt(string base64Encrypted, string base64IV)
        {
            var rijndael = new RijndaelManaged
            {
                BlockSize = 128,
                Key = k,
                IV = Convert.FromBase64String(base64IV),
            };
            var decr = rijndael.CreateDecryptor();
            byte[] b = Convert.FromBase64String(base64Encrypted);
            return Encoding.UTF8.GetString(decr.TransformFinalBlock(b, 0, b.Length));
        }

        public string GenerateNewIv()
        {
            var rijndael = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 128
            };
            rijndael.GenerateIV();
            return Convert.ToBase64String(rijndael.IV);
        }

        public static string GenerateNewKey()
        {
            var rijndael = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                KeySize = 256,
                BlockSize = 128
            };
            rijndael.GenerateKey();
            return Convert.ToBase64String(rijndael.Key);
        }

        //Konvertovanje
        public string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        public string BinaryToString(string data)
        {
            List<Byte> bList = new List<Byte>();

            for (int i = 0; i < data.Length; i = i + 8)
            {
                bList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(bList.ToArray());
        }
    }
}
