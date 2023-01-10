/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2021-2022 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI..........:2
** ÖĞRENCİ ADI............:Samet Guzel
** ÖĞRENCİ NUMARASI.......:G201210086
** DERSİN ALINDIĞI GRUP...:2. Ogretim A Grubu
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ndp_odev2
{
    public class Form1 : Form
    {
        private static readonly string[] sayilar_bir =
            {string.Empty, "BIR", "IKI", "UC", "DORT", "BES", "ALTI", "YEDI", "SEKIZ", "DOKUZ"};

        private static readonly string[] sayilar_on =
            {string.Empty, "ON", "YIRMI", "OTUZ", "KIRK", "ELLI", "ALTMIS", "YETMIS", "SEKSEN", "DOKSAN"};

        private readonly IContainer components = null;

        private Button btnHesapla;
        private Label label1;
        private Label label2;
        private Label lblYazi;
        private TextBox txtSayi;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnHesapla = new Button();
            lblYazi = new Label();
            txtSayi = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnHesapla
            // 
            btnHesapla.Location = new Point(196, 215);
            btnHesapla.Name = "btnHesapla";
            btnHesapla.Size = new Size(98, 39);
            btnHesapla.TabIndex = 0;
            btnHesapla.Text = "HESAPLA";
            btnHesapla.UseVisualStyleBackColor = true;
            btnHesapla.Click += btnHesapla_Click;
            // 
            // lblYazi
            // 
            lblYazi.AutoSize = true;
            lblYazi.Location = new Point(221, 153);
            lblYazi.Name = "lblYazi";
            lblYazi.Size = new Size(0, 15);
            lblYazi.TabIndex = 1;
            // 
            // txtSayi
            // 
            txtSayi.Location = new Point(196, 68);
            txtSayi.Name = "txtSayi";
            txtSayi.Size = new Size(98, 23);
            txtSayi.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 71);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 3;
            label1.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(117, 153);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 4;
            label2.Text = "Y";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 299);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSayi);
            Controls.Add(lblYazi);
            Controls.Add(btnHesapla);
            Name = "Form1";
            Text = "Fonksiyon Hesabi";
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            string[] sayi = txtSayi.Text.Split('.');
            if (sayi.Length == 0)
            {
                MessageBox.Show("Hatali giris");
                return;
            }

            var okunuslar = new List<string>();
            string okunus_fin = string.Empty;
            if (sayi.Length > 1)
            {
                string kurus = sayi[1];
                if (kurus.Length > 2)
                {
                    MessageBox.Show("Hatali giris");
                    return;
                }

                if (kurus.Length > 0)
                {
                    int birler = kurus[kurus.Length - 1] - '0';
                    if (birler != 0)
                        okunuslar.Add("KURUS");
                    okunuslar.Add(sayilar_bir[birler]);
                }

                if (kurus.Length > 1)
                {
                    int onlar = kurus[kurus.Length - 2] - '0';
                    okunuslar.Add(sayilar_on[onlar]);
                }
            }

            if (sayi.Length > 0)
            {
                string lira = sayi[0];
                if (lira.Length > 5)
                {
                    MessageBox.Show("Hatali giris");
                    return;
                }

                if (lira.Length > 0)
                {
                    int birler = lira[lira.Length - 1] - '0';
                    if (birler != 0)
                        okunuslar.Add("TL");
                    okunuslar.Add(sayilar_bir[birler]);
                }

                if (lira.Length > 1)
                {
                    int onlar = lira[lira.Length - 2] - '0';
                    okunuslar.Add(sayilar_on[onlar]);
                }

                if (lira.Length > 2)
                {
                    int yuzler = lira[lira.Length - 3] - '0';
                    if (yuzler != 0)
                        okunuslar.Add("YUZ");
                    if (yuzler != 1)
                        okunuslar.Add(sayilar_bir[yuzler]);
                }

                if (lira.Length > 4)
                {
                    int binler = lira[lira.Length - 4] - '0';
                    int onbinler = lira[lira.Length - 5] - '0';

                    if (binler != 0)
                        okunuslar.Add("BIN");
                    if (binler != 1)
                        okunuslar.Add(sayilar_bir[binler]);

                    if (onbinler != 0)
                        okunuslar.Add("BIN");
                    okunuslar.Add(sayilar_on[onbinler]);

                    if (okunuslar.Count(s => s == "BIN") == 2)
                        okunuslar.RemoveAt(okunuslar.LastIndexOf("BIN"));
                }
                else if (lira.Length > 3)
                {
                    int binler = lira[lira.Length - 4] - '0';
                    if (binler != 0)
                        okunuslar.Add("BIN");
                    if (binler != 1)
                        okunuslar.Add(sayilar_bir[binler]);
                }
            }

            okunuslar.Reverse();
            foreach (string okunus in okunuslar)
                if (okunus != string.Empty)
                    okunus_fin += $"{okunus} ";

            lblYazi.Text = okunus_fin;
        }
    }

    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
