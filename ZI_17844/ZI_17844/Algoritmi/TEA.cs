using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17844
{
    internal class TEA
    {
        //TEA algoritam-A3

        private string encrMess;
        private uint[] _key;
        private const uint delta = 0x9e3779b9;

        public TEA() { }
        public void SetMess(string msg)
        {
            this.encrMess = msg;
        }

        public string GetMess()
        {
            return this.encrMess;
        }

        //Code i Decode 
        private void code(uint[] vect, uint[] k)
        {
            uint y = vect[0];
            uint z = vect[1];
            uint s = 0;
            uint delta = 0x9e3779b9;

            for(uint n=32; n>0; n--)
            {
                y += (z << 4 ^ z >> 5) + z ^ s + k[s & 3];
                s += delta;
                z += (y << 4 ^ y >> 5) + y ^ s + k[s >> 11 & 3];
            }

            vect[0] = y;
            vect[1] = z;
        }

        private void decode(uint[] vect, uint[] k)
        {
            uint s;
            uint y = vect[0];
            uint z = vect[1];
            uint delta = 0x9e3779b9;

            s = delta * 32;//<<5

            for (uint n = 32; n > 0; n--)
            {
                z -= (y << 4 ^ y >> 5) + y ^ s + k[s >> 11 & 3];
                s -= delta;
                y -= (z << 4 ^ z >> 5) + z ^ s + k[s & 3];
            }

            vect[0] = y;
            vect[1] = z;
        }

        //Encrypt metoda
        public string Encrypt_TEA(string data, string k)
        {
            uint[] formatted = FormatKey(k);
            if (data.Length % 2 != 0)
                data += '\0';
            byte[] dataB = ASCIIEncoding.ASCII.GetBytes(data);

            string cipher = string.Empty;
            uint[] temp = new uint[2];

            for (int i = 0; i < dataB.Length; i = i + 2)
            {
                temp[0] = dataB[i];
                temp[1] = dataB[i + 1];
                code(temp, formatted);
                cipher += ConvertUIntToString(temp[0]) + ConvertUIntToString(temp[1]);
            }

            return cipher;
        }

        //Decrypt metoda
        public string Decrypt_TEA(string data, string k)
        {
            uint[] formatted = FormatKey(k);

            int x = 0;
            uint[] temp = new uint[2];
            byte[] dataB = new byte[data.Length / 8 * 2];

            for (int i = 0; i < data.Length; i = i + 8)
            {
                temp[0] = ConvertStringToUInt(data.Substring(i, 4));
                temp[1] = ConvertStringToUInt(data.Substring(i + 4, 4));

                decode(temp, formatted);
                dataB[x++] = (byte)temp[0];
                dataB[x++] = (byte)temp[1];
            }
            string deciphered = ASCIIEncoding.ASCII.GetString(dataB, 0, dataB.Length);
            if (deciphered[deciphered.Length - 1] == '\0')
                deciphered = deciphered.Substring(0, deciphered.Length - 1);
            return deciphered;
        }

        public uint[] FormatKey(string k)
        {
            k = k.PadRight(16, ' ').Substring(0, 16);
            uint[] formatted = new uint[4];
            int j = 0;
            for (int i = 0; i < k.Length; i = i + 4)
            {
                formatted[j] = ConvertStringToUInt(k.Substring(i, 4));
                j++;
            }
            return formatted;
        }

        public string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        private string ConvertUIntToString(uint input)
        {
            StringBuilder output = new StringBuilder();
            output.Append((char)((input & 0xFF)));
            output.Append((char)((input >> 8) & 0xFF));
            output.Append((char)((input >> 16) & 0xFF));
            output.Append((char)((input >> 24) & 0xFF));
            return output.ToString();
        }

        private uint ConvertStringToUInt(string Input)
        {
            uint output;
            output = ((uint)Input[0]);
            output += ((uint)Input[1] << 8);
            output += ((uint)Input[2] << 16);
            output += ((uint)Input[3] << 24);
            return output;
        }

        //Bitmapa
        public TEA(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("Key");
            if (key.Length != 16)
                throw new ArgumentException("Key length must be 128 bits");

            _key = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                _key[i] = BitConverter.ToUInt32(key, i * 4);
            }
        }

        public void EncryptBitmap(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Data");

            int paddedLength = (data.Length + 7) / 8 * 8;

            uint[] v = new uint[2];
            uint[] k = _key;
            for (int i = 0; i < paddedLength; i += 8)
            {
                v[0] = BitConverter.ToUInt32(data, i);
                v[1] = BitConverter.ToUInt32(data, i + 4);
                uint sum = 0;
                for (int j = 0; j < 32; j++)
                {
                    sum += delta;
                    v[0] += ((v[1] << 4) + k[0]) ^ (v[1] + sum) ^ ((v[1] >> 5) + k[1]);
                    v[1] += ((v[0] << 4) + k[2]) ^ (v[0] + sum) ^ ((v[0] >> 5) + k[3]);
                }
                Array.Copy(BitConverter.GetBytes(v[0]), 0, data, i, 4);
                Array.Copy(BitConverter.GetBytes(v[1]), 0, data, i + 4, 4);
            }
        }

        public void DecryptBitmap(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Data");

            uint[] v = new uint[2];
            uint[] k = _key;
            for (int i = 0; i < data.Length; i += 8)
            {
                v[0] = BitConverter.ToUInt32(data, i);
                v[1] = BitConverter.ToUInt32(data, i + 4);

                uint sum = delta << 5;
                for (int j = 0; j < 32; j++)
                {
                    v[1] -= ((v[0] << 4) + k[2]) ^ (v[0] + sum) ^ ((v[0] >> 5) + k[3]);
                    v[0] -= ((v[1] << 4) + k[0]) ^ (v[1] + sum) ^ ((v[1] >> 5) + k[1]);
                    sum -= delta;
                }
                Array.Copy(BitConverter.GetBytes(v[0]), 0, data, i, 4);
                Array.Copy(BitConverter.GetBytes(v[1]), 0, data, i + 4, 4);
            }
        }
    }
}
