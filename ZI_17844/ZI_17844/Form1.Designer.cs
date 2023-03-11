namespace ZI_17844
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnc = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnEncryptF = new System.Windows.Forms.Button();
            this.btnDecryptF = new System.Windows.Forms.Button();
            this.btnCRCCompare = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonRC4 = new System.Windows.Forms.RadioButton();
            this.buttonEnigma = new System.Windows.Forms.RadioButton();
            this.buttonTEA = new System.Windows.Forms.RadioButton();
            this.buttonCBC = new System.Windows.Forms.RadioButton();
            this.txtDecr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEncriptBitmap = new System.Windows.Forms.Button();
            this.btnDecriptBitmap = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Algoritam:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kljuc:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(126, 62);
            this.txtKey.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(271, 22);
            this.txtKey.TabIndex = 4;
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.MediumBlue;
            this.btnDecrypt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDecrypt.Location = new System.Drawing.Point(268, 96);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(127, 37);
            this.btnDecrypt.TabIndex = 2;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.MediumBlue;
            this.btnEncrypt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEncrypt.Location = new System.Drawing.Point(126, 96);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(119, 37);
            this.btnEncrypt.TabIndex = 1;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Enkriptovani tekst";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tekst za enkriptovanje";
            // 
            // txtEnc
            // 
            this.txtEnc.Location = new System.Drawing.Point(430, 177);
            this.txtEnc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEnc.Multiline = true;
            this.txtEnc.Name = "txtEnc";
            this.txtEnc.Size = new System.Drawing.Size(432, 75);
            this.txtEnc.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(430, 33);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(432, 75);
            this.textBox1.TabIndex = 0;
            // 
            // btnEncryptF
            // 
            this.btnEncryptF.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEncryptF.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEncryptF.Location = new System.Drawing.Point(126, 177);
            this.btnEncryptF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEncryptF.Name = "btnEncryptF";
            this.btnEncryptF.Size = new System.Drawing.Size(119, 37);
            this.btnEncryptF.TabIndex = 3;
            this.btnEncryptF.Text = "Encrypt";
            this.btnEncryptF.UseVisualStyleBackColor = false;
            this.btnEncryptF.Click += new System.EventHandler(this.btnEncryptFile_Click);
            // 
            // btnDecryptF
            // 
            this.btnDecryptF.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDecryptF.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDecryptF.Location = new System.Drawing.Point(268, 177);
            this.btnDecryptF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecryptF.Name = "btnDecryptF";
            this.btnDecryptF.Size = new System.Drawing.Size(127, 37);
            this.btnDecryptF.TabIndex = 4;
            this.btnDecryptF.Text = "Decrypt";
            this.btnDecryptF.UseVisualStyleBackColor = false;
            this.btnDecryptF.Click += new System.EventHandler(this.btnDecryptFile_Click);
            // 
            // btnCRCCompare
            // 
            this.btnCRCCompare.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnCRCCompare.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCRCCompare.Location = new System.Drawing.Point(126, 332);
            this.btnCRCCompare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCRCCompare.Name = "btnCRCCompare";
            this.btnCRCCompare.Size = new System.Drawing.Size(119, 37);
            this.btnCRCCompare.TabIndex = 5;
            this.btnCRCCompare.Text = "CRC Compare";
            this.btnCRCCompare.UseVisualStyleBackColor = false;
            this.btnCRCCompare.Click += new System.EventHandler(this.btnCRCCompare_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(68, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fajl:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 342);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Uporedi fajlove:";
            // 
            // buttonRC4
            // 
            this.buttonRC4.AutoSize = true;
            this.buttonRC4.Location = new System.Drawing.Point(126, 33);
            this.buttonRC4.Name = "buttonRC4";
            this.buttonRC4.Size = new System.Drawing.Size(54, 20);
            this.buttonRC4.TabIndex = 15;
            this.buttonRC4.TabStop = true;
            this.buttonRC4.Text = "RC4";
            this.buttonRC4.UseVisualStyleBackColor = true;
            // 
            // buttonEnigma
            // 
            this.buttonEnigma.AutoSize = true;
            this.buttonEnigma.Location = new System.Drawing.Point(186, 33);
            this.buttonEnigma.Name = "buttonEnigma";
            this.buttonEnigma.Size = new System.Drawing.Size(74, 20);
            this.buttonEnigma.TabIndex = 16;
            this.buttonEnigma.TabStop = true;
            this.buttonEnigma.Text = "Enigma";
            this.buttonEnigma.UseVisualStyleBackColor = true;
            // 
            // buttonTEA
            // 
            this.buttonTEA.AutoSize = true;
            this.buttonTEA.Location = new System.Drawing.Point(268, 33);
            this.buttonTEA.Name = "buttonTEA";
            this.buttonTEA.Size = new System.Drawing.Size(55, 20);
            this.buttonTEA.TabIndex = 17;
            this.buttonTEA.TabStop = true;
            this.buttonTEA.Text = "TEA";
            this.buttonTEA.UseVisualStyleBackColor = true;
            // 
            // buttonCBC
            // 
            this.buttonCBC.AutoSize = true;
            this.buttonCBC.Location = new System.Drawing.Point(340, 33);
            this.buttonCBC.Name = "buttonCBC";
            this.buttonCBC.Size = new System.Drawing.Size(55, 20);
            this.buttonCBC.TabIndex = 18;
            this.buttonCBC.TabStop = true;
            this.buttonCBC.Text = "CBC";
            this.buttonCBC.UseVisualStyleBackColor = true;
            // 
            // txtDecr
            // 
            this.txtDecr.Location = new System.Drawing.Point(430, 316);
            this.txtDecr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDecr.Multiline = true;
            this.txtDecr.Name = "txtDecr";
            this.txtDecr.Size = new System.Drawing.Size(432, 75);
            this.txtDecr.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dekriptovani tekst";
            // 
            // btnEncriptBitmap
            // 
            this.btnEncriptBitmap.BackColor = System.Drawing.Color.Navy;
            this.btnEncriptBitmap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEncriptBitmap.Location = new System.Drawing.Point(126, 256);
            this.btnEncriptBitmap.Name = "btnEncriptBitmap";
            this.btnEncriptBitmap.Size = new System.Drawing.Size(119, 37);
            this.btnEncriptBitmap.TabIndex = 21;
            this.btnEncriptBitmap.Text = "Encrypt";
            this.btnEncriptBitmap.UseVisualStyleBackColor = false;
            this.btnEncriptBitmap.Click += new System.EventHandler(this.btnEncriptBitmap_Click);
            // 
            // btnDecriptBitmap
            // 
            this.btnDecriptBitmap.BackColor = System.Drawing.Color.Navy;
            this.btnDecriptBitmap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDecriptBitmap.Location = new System.Drawing.Point(268, 256);
            this.btnDecriptBitmap.Name = "btnDecriptBitmap";
            this.btnDecriptBitmap.Size = new System.Drawing.Size(119, 37);
            this.btnDecriptBitmap.TabIndex = 22;
            this.btnDecriptBitmap.Text = "Decrypt";
            this.btnDecriptBitmap.UseVisualStyleBackColor = false;
            this.btnDecriptBitmap.Click += new System.EventHandler(this.btnDecriptBitmap_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Bitmapa:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(323, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "*Za bitmape je neophodno da kljuc bude duzine 128b";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 438);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnDecriptBitmap);
            this.Controls.Add(this.btnEncriptBitmap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDecr);
            this.Controls.Add(this.buttonCBC);
            this.Controls.Add(this.buttonTEA);
            this.Controls.Add(this.buttonEnigma);
            this.Controls.Add(this.buttonRC4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEnc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEncryptF);
            this.Controls.Add(this.btnDecryptF);
            this.Controls.Add(this.btnCRCCompare);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Forma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtEnc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEncryptF;
        private System.Windows.Forms.Button btnDecryptF;
        private System.Windows.Forms.Button btnCRCCompare;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton buttonRC4;
        private System.Windows.Forms.RadioButton buttonEnigma;
        private System.Windows.Forms.RadioButton buttonTEA;
        private System.Windows.Forms.RadioButton buttonCBC;
        private System.Windows.Forms.TextBox txtDecr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnEncriptBitmap;
        private System.Windows.Forms.Button btnDecriptBitmap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

