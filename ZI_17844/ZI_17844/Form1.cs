using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZI_17844
{
    public partial class Form1 : Form
    {
        //za enigmu
        protected static string r1 = "QWERTZUIOASDFGHJKPYXCVBNML";
        protected static string r2 = "ZAQWSXCDERFVBGTYHNMJUIKLOP";
        protected static string r3 = "PLOKMIJNUHBYGVTFCRDXESZWAQ";

        protected static string refl = "FVPJIAOYEDRZXWGCTKUQSBNMHL";
        protected static string pb = "JKHGFEDCBAZYXWVUTSRQPONMLI";

        //za cbc
        protected static string key = "A/Dj4u1ftDFK5+77i8as80v2IughrtoP5yee00ab6tQ=";
        protected static string iv = "gaOr3uvhZEwFeSbRHwlHcg==";

        RC4 rc4_alg = new RC4();
        TEA tea_alg = new TEA();
        CBC cbc_alg = new CBC(key);//key
        Enigma enigma_alg = new Enigma();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if(buttonRC4.Checked==true)
            {
                String s1 = textBox1.Text.ToString();
                String k = txtKey.Text.ToString();
                if (k.Length == 0)
                    MessageBox.Show("Nije unet kljuc!");
                else
                {
                    Invoke(new Action(() => txtEnc.Clear()));
                    byte[] encrB = rc4_alg.Encr_RC4(s1, k);
                    rc4_alg.SetBytes(encrB);
                    string s2 = rc4_alg.ToBinaryString(Encoding.UTF8, Encoding.ASCII.GetString(encrB));
                    Invoke(new Action(() => txtDecr.Clear()));
                    Invoke(new Action(() => txtEnc.AppendText(rc4_alg.ToBinaryString(Encoding.UTF8, Encoding.ASCII.GetString(encrB)))));
                    Invoke(new Action(() => textBox1.Clear()));
                }
            }
            else if(buttonEnigma.Checked==true)
            {
                var unetiTekst = textBox1.Text;
                Invoke(new Action(() => txtEnc.Clear()));
                bool check = unetiTekst.All(karakter => char.IsUpper(karakter));
                if (check)
                {
                    var encrText = enigma_alg.Encrypt_Enigma(unetiTekst, r1, r2, r3, refl, pb);
                    Invoke(new Action(() => txtDecr.Clear()));
                    Invoke(new Action(() => txtEnc.AppendText(encrText)));
                    Invoke(new Action(() => textBox1.Clear()));
                }
                else
                    MessageBox.Show("Unesite iskljucivo velika slova za enkriptovanje!");
            }
            else if(buttonTEA.Checked==true)
            {
                String s1 = textBox1.Text.ToString();
                String k = txtKey.Text.ToString();
                if (k.Length == 0)
                    MessageBox.Show("Nije unet kljuc!");
                else
                {
                    Invoke(new Action(() => txtEnc.Clear()));
                    string encrMess = tea_alg.Encrypt_TEA(s1, k);
                    tea_alg.SetMess(encrMess);
                    Invoke(new Action(() => txtDecr.Clear()));
                    Invoke(new Action(() => txtEnc.AppendText(tea_alg.ToBinaryString(Encoding.UTF8, encrMess))));
                    Invoke(new Action(() => textBox1.Clear()));
                }
            }
            else if(buttonCBC.Checked==true)
            {
                String s1 = textBox1.Text.ToString();
                string encrStr = cbc_alg.Encrypt(s1, iv);
                cbc_alg.Set(encrStr);
                Invoke(new Action(() => txtDecr.Clear()));
                Invoke(new Action(() => txtEnc.Clear()));
                Invoke(new Action(() => txtEnc.AppendText(cbc_alg.ToBinaryString(Encoding.UTF8, encrStr))));
                Invoke(new Action(() => textBox1.Clear()));
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if(buttonRC4.Checked==true)
            {
                String s1 = txtEnc.Text.ToString();
                String k = txtKey.Text.ToString();
                if (k.Length == 0)
                    MessageBox.Show("Nije unet kljuc!");
                else
                {
                    Invoke(new Action(() => txtDecr.Clear()));
                    Invoke(new Action(() => txtDecr.AppendText(Encoding.ASCII.GetString(rc4_alg.Decr_RC4(k)))));
                    Invoke(new Action(() => txtEnc.Clear()));
                }
            }
            else if(buttonEnigma.Checked==true)
            {
                var tekst = txtEnc.Text;
                var decrText = enigma_alg.Decrypt_Enigma(tekst, r1, r2, r3, refl, pb);
                Invoke(new Action(() => txtDecr.Clear()));
                Invoke(new Action(() => txtDecr.AppendText(decrText)));
                Invoke(new Action(() => txtEnc.Clear()));
            }
            else if(buttonTEA.Checked==true)
            {
                String k = txtKey.Text.ToString();
                string encrMess = tea_alg.GetMess();
                if (k.Length == 0)
                    MessageBox.Show("Nije unet kljuc!");
                else
                {
                    Invoke(new Action(() => txtDecr.Clear()));
                    Invoke(new Action(() => txtDecr.AppendText(tea_alg.Decrypt_TEA(encrMess, k))));
                    Invoke(new Action(() => txtEnc.Clear()));
                }
            }
            else if (buttonCBC.Checked==true)
            {
                string decr = cbc_alg.Decrypt(cbc_alg.Get(), iv);
                Invoke(new Action(() => txtDecr.Clear()));
                Invoke(new Action(() => txtDecr.AppendText(decr)));
                Invoke(new Action(() => txtEnc.Clear()));
            }
        }

        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            //Fajlovi E
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text|*.txt|All|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var putanja = ofd.FileName;
                    using (var fileStream = File.OpenRead(putanja))
                    {
                        using (var sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "Text |*.txt";
                            sfd.FileName = "enkriptovano.txt";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                var encrFilePath = sfd.FileName;
                                using (var encrFileStream = File.OpenWrite(encrFilePath))
                                {
                                    var aes = Aes.Create();
                                    aes.Key = Convert.FromBase64String(key);
                                    aes.IV = Convert.FromBase64String(iv);
                                    aes.Mode = CipherMode.CBC;
                                    using (var encr = aes.CreateEncryptor())
                                    {
                                        using (var cryptoStream = new CryptoStream(encrFileStream, encr, CryptoStreamMode.Write))
                                        {
                                            fileStream.CopyTo(cryptoStream);
                                        }
                                    }
                                }
                                string title = "Save";
                                string message = "Fajl sacuvan kao: " + encrFilePath;
                                MessageBox.Show(message,title);
                            }
                        }
                    }
                }
            }
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            //Fajlovi D
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text|*.txt|All|*.*"; ;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var encrFilePath = ofd.FileName;
                    using (var encrFileStream = File.OpenRead(encrFilePath))
                    {
                        using (var sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "Text |*.txt";
                            sfd.FileName = "dekriptovano.txt";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                var decrFilePath = sfd.FileName;
                                using (var decrFileStream = File.OpenWrite(decrFilePath))
                                {
                                    var aes = Aes.Create();
                                    aes.Key = Convert.FromBase64String(key);
                                    aes.IV = Convert.FromBase64String("gaOr3uvhZEwFeSbRHwlHcg==");
                                    aes.Mode = CipherMode.CBC;
                                    using (var decr = aes.CreateDecryptor())
                                    {
                                        using (var cryptoStream = new CryptoStream(encrFileStream, decr, CryptoStreamMode.Read))
                                        {
                                            cryptoStream.CopyTo(decrFileStream);
                                        }
                                    }
                                }
                                string title = "Save";
                                string message = "Fajl sacuvan kao: " + decrFilePath;
                                MessageBox.Show(message,title);
                            }
                        }
                    }
                }
            }
        }

        private void btnCRCCompare_Click(object sender, EventArgs e)
        {
            //Compare Fajlova
            using (var ofd_1 = new OpenFileDialog())
            {
                ofd_1.Filter = "All files (*.*)|*.*";
                ofd_1.Title = "Izaberite 1. fajl";
                if (ofd_1.ShowDialog() == DialogResult.OK)
                {
                    var first = ofd_1.FileName;
                    using (var ofd_2 = new OpenFileDialog())
                    {
                        ofd_2.Filter = "All files (*.*)|*.*";
                        ofd_2.Title = "Izaberite 2. fajl";
                        if (ofd_2.ShowDialog() == DialogResult.OK)
                        {
                            var second = ofd_2.FileName;
                            using (var fileStream_1 = File.OpenRead(first))
                            {
                                var crc = new CRC();
                                var hash_first = crc.ComputeHash(fileStream_1);
                                using (var fileStream_2 = File.OpenRead(second))
                                {
                                    var hash_second = crc.ComputeHash(fileStream_2);
                                    if (hash_first.SequenceEqual(hash_second))
                                    {
                                        string title1 = "==";
                                        string message1 = "Fajlovi su isti";
                                        MessageBox.Show(message1,title1);
                                    }
                                    else
                                    {
                                        string title2 = "!=";
                                        string message2 = "Fajlovi su razliciti";
                                        MessageBox.Show(message2,title2);
                                       
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnEncriptBitmap_Click(object sender, EventArgs e)
        {
            //Bitmap Encr
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap Image|*.bmp";
            openFileDialog.Title = "Izaberite bitmapu za enkripciju";
            if (txtKey.Text.Length == 0)
                MessageBox.Show("Nije unet kljuc!");
            else
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    byte[] key = Encoding.UTF8.GetBytes(txtKey.Text);
                    TEA tea = new TEA(key);
                    tea.EncryptBitmap(imageBytes);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Bitmap Image|*.bmp";
                    saveFileDialog.Title = "Sacuvajte generisanu bitmapu";
                    saveFileDialog.FileName = "encryptedBitmap.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, imageBytes);
                    }
                    string title = "Save";
                    string message = "Bitmapa sacuvana kao: " + saveFileDialog.FileName;
                    MessageBox.Show(message, title);
                }
            }
        }

        private void btnDecriptBitmap_Click(object sender, EventArgs e)
        {
            //Bitmap Decr
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap Image|*.bmp";
            openFileDialog.Title = "Izaberite bitmapu za dekripciju";
            if (txtKey.Text.Length == 0)
                MessageBox.Show("Nije unet kljuc!");
            else
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    byte[] encryptedImageBytes = File.ReadAllBytes(openFileDialog.FileName);
                    byte[] key = Encoding.UTF8.GetBytes(txtKey.Text);
                    TEA tea = new TEA(key);
                    tea.DecryptBitmap(encryptedImageBytes);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Bitmap Image|*.bmp";
                    saveFileDialog.Title = "Sacuvajte dekriptovanu bitmapu";
                    saveFileDialog.FileName = "decryptedBitmap.bmp";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, encryptedImageBytes);
                    }
                    string title = "Save";
                    string message = "Bitmapa sacuvana kao: " + saveFileDialog.FileName;
                    MessageBox.Show(message,title);
                }
            }
        }
    }
}
