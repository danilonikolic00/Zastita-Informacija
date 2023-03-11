using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17844
{
    internal class RC4
    {
        //RC4 Algoritam-A1

        private byte[] encrB;

        public void SetBytes(byte[] b)
        {
            this.encrB = b;
        }

        public byte[] getBytes()
        {
            return this.encrB;
        }

        //Encryption metoda
        public byte[] Encr_RC4(string s, string k)
        {

            var asciiKeyB = Encoding.ASCII.GetBytes(k);
            var box = Enumerable.Range(0, 256).ToArray();

            var j = 0;

            for (var i = 0; i <= 255; i++)
            {
                j = (asciiKeyB[i % asciiKeyB.Length]+ j + box[i]) % 256;
                box[j] = box[i];
                box[i] = j;
            }

            var encrBytes = PseudoRc4(box, Encoding.ASCII.GetBytes(s));

            return encrBytes;
        }

        //Decryption metoda
        public byte[] Decr_RC4(string k)
        {

            var asciiKeyB = Encoding.ASCII.GetBytes(k);
            var box = Enumerable.Range(0, 256).ToArray();

            var j = 0;

            for (var i = 0; i <= 255; i++)
            {
                j = (asciiKeyB[i % asciiKeyB.Length] + j + box[i]) % 256;
                box[j] = box[i];
                box[i] = j;
            }

            return PseudoRc4(box, encrB);
        }

        //PseudoRandomRC4
        public static byte[] PseudoRc4(int[] box, byte[] messB)
        {

            var i = 0;
            var j = 0;
            var counter = 0;
            var temp_box = new int[box.Length];
            var res = new byte[messB.Length];

            Array.Copy(box, temp_box, temp_box.Length);

            foreach (var txtB in messB)
            {
                i = (i + 1) % 256;
                j = ( temp_box[i]+j ) % 256;
                var temp = temp_box[i];
                temp_box[i] = temp_box[j];
                temp_box[j] = temp;
                var t = (temp_box[i] + temp_box[j]) % 256;
                var k=temp_box[t];

                var pom = txtB ^ k;
                res[counter] = (byte)pom;
                counter++;
            }
            return res;
        }

        public string ToBinaryString(Encoding enc, string text)
        {
            return string.Join("", enc.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }
    }
}
