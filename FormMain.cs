using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonelMaasApp
{
    public partial class FormMain : Form
    {
        private bool koyuTema = false;

        public FormMain()
        {
            InitializeComponent();
            TemaUygula();
        }

        private void InitializeComponent()
        {
            this.Text = "Personel Maaş Takip Sistemi";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnTemaDegistir = new Button();
            btnTemaDegistir.Text = "Tema Değiştir";
            btnTemaDegistir.Location = new Point(20, 20);
            btnTemaDegistir.Click += BtnTemaDegistir_Click;

            Button btnPersonelEkle = new Button();
            btnPersonelEkle.Text = "Personel Ekle";
            btnPersonelEkle.Location = new Point(20, 70);
            btnPersonelEkle.Click += (s, e) => new FormPersonelEkle().ShowDialog();

            Button btnMaasHesapla = new Button();
            btnMaasHesapla.Text = "Maaş Hesapla";
            btnMaasHesapla.Location = new Point(20, 120);
            btnMaasHesapla.Click += (s, e) => new FormMaasHesapla().ShowDialog();

            Button btnCikis = new Button();
            btnCikis.Text = "Çıkış";
            btnCikis.Location = new Point(20, 170);
            btnCikis.Click += (s, e) => this.Close();

            this.Controls.Add(btnTemaDegistir);
            this.Controls.Add(btnPersonelEkle);
            this.Controls.Add(btnMaasHesapla);
            this.Controls.Add(btnCikis);
        }

        private void BtnTemaDegistir_Click(object sender, EventArgs e)
        {
            koyuTema = !koyuTema;
            TemaUygula();
        }

        private void TemaUygula()
        {
            if (koyuTema)
            {
                this.BackColor = Color.Black;
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.White;
                    ctrl.BackColor = Color.FromArgb(30, 30, 30);
                }
            }
            else
            {
                this.BackColor = Color.White;
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.ForeColor = Color.Black;
                    ctrl.BackColor = SystemColors.Control;
                }
            }
        }
    }
}
