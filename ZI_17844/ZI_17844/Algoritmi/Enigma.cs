using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_17844
{
    public class Enigma
    {
        //Enigma-A2

        //Encryption Metoda
        public string Encrypt_Enigma(string plain, string r1, string r2, string r3, string reflector, string plugboard)
        {
            var rot1 = r1.ToCharArray();
            var rot2 = r2.ToCharArray();
            var rot3 = r3.ToCharArray();

            var refl = reflector.ToCharArray();

            var pb = plugboard.ToCharArray();

            var cipher = "";

            for (var i = 0; i < plain.Length; i++)
            {
                var currChar = plain[i];

                StepRotor(ref rot1);

                if (i % 26 == 0)
                {
                    StepRotor(ref rot2);

                    if (i % (26 ^ 2) == 0)
                    {
                        StepRotor(ref rot3);
                    }
                }

                currChar = ApplyPB(currChar, pb);

                currChar = ApplyRotor(currChar, rot1);
                currChar = ApplyRotor(currChar, rot2);
                currChar = ApplyRotor(currChar, rot3);

                currChar = ApplyReflector(currChar, refl);

                currChar = ApplyRotor(currChar, rot3, true);
                currChar = ApplyRotor(currChar, rot2, true);
                currChar = ApplyRotor(currChar, rot1, true);

                currChar = ApplyPB(currChar, pb);

                cipher += currChar;
            }

            return cipher;
        }

        //Decryption metoda
        public string Decrypt_Enigma(string cipher, string r1, string r2, string r3, string reflector, string plugboard)
        {
            var rot1 = r1.ToCharArray();
            var rot2 = r2.ToCharArray();
            var rot3 = r3.ToCharArray();

            var refl = reflector.ToCharArray();

            var pb = plugboard.ToCharArray();

            var plain = "";

            for (var i = 0; i < cipher.Length; i++)
            {
                var currChar = cipher[i];

                StepRotor(ref rot1);
                if (i % 26 == 0)
                {
                    StepRotor(ref rot2);
                    if (i % (26 ^ 2) == 0)
                    {
                        StepRotor(ref rot3);
                    }
                }

                currChar = ApplyPB(currChar, pb);

                currChar = ApplyRotor(currChar, rot1);
                currChar = ApplyRotor(currChar, rot2);
                currChar = ApplyRotor(currChar, rot3);

                currChar = ApplyReflector(currChar, refl);

                currChar = ApplyRotor(currChar, rot3, true);
                currChar = ApplyRotor(currChar, rot2, true);
                currChar = ApplyRotor(currChar, rot1, true);

                currChar = ApplyPB(currChar, pb);

                plain += currChar;
            }
            return plain;
        }

        private void StepRotor(ref char[] rotor)
        {
            var first = rotor[0];
            Array.Copy(rotor, 1, rotor, 0, rotor.Length - 1);
            rotor[rotor.Length - 1] = first;
        }

        private char ApplyReflector(char currChar, char[] refl)
        {
            var ind = Array.IndexOf(refl, currChar);
            return refl[(ind + 13) % 26];
        }

        private char ApplyRotor(char currChar, char[] rot, bool reverse = false)
        {
            var ind = Array.IndexOf(reverse ? Enumerable.Range('A', 26).Select(x => (char)x).ToArray() : rot, currChar);
            if(reverse)
            {
                return (char)('A' + ind);
            }
            else
            {
                return (char)(rot[ind]);
            }
        }

        private char ApplyPB(char currChar, char[] pb)
        {
            var index = Array.IndexOf(pb, currChar);
            if(index>=0)
            {
                return pb[index ^ 1];
            }
            else
            {
                return currChar; 
            }
        }

    }
}
