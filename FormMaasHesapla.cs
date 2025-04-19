using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonelMaasApp
{
    public class FormMaasHesapla : Form
    {
        TextBox txtGunlukUcret, txtGunSayisi, txtPrim;
        Label lblSonuc;

        public FormMaasHesapla()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Maaş Hesapla";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblGunlukUcret = new Label() { Text = "Günlük Ücret:", Location = new Point(30, 30), AutoSize = true };
            txtGunlukUcret = new TextBox() { Location = new Point(150, 30), Width = 150 };

            Label lblGunSayisi = new Label() { Text = "Gün Sayısı:", Location = new Point(30, 70), AutoSize = true };
            txtGunSayisi = new TextBox() { Location = new Point(150, 70), Width = 150 };

            Label lblPrim = new Label() { Text = "Prim (varsa):", Location = new Point(30, 110), AutoSize = true };
            txtPrim = new TextBox() { Location = new Point(150, 110), Width = 150 };

            Button btnHesapla = new Button() { Text = "HESAPLA", Location = new Point(150, 160), Width = 100 };
            btnHesapla.Click += BtnHesapla_Click;

            lblSonuc = new Label() { Text = "Toplam Maaş: ", Location = new Point(30, 220), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };

            this.Controls.AddRange(new Control[]
            {
                lblGunlukUcret, txtGunlukUcret,
                lblGunSayisi, txtGunSayisi,
                lblPrim, txtPrim,
                btnHesapla, lblSonuc
            });
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                decimal gunlukUcret = Convert.ToDecimal(txtGunlukUcret.Text);
                int gunSayisi = Convert.ToInt32(txtGunSayisi.Text);
                decimal prim = string.IsNullOrEmpty(txtPrim.Text) ? 0 : Convert.ToDecimal(txtPrim.Text);

                decimal toplamMaas = (gunlukUcret * gunSayisi) + prim;
                lblSonuc.Text = $"Toplam Maaş: {toplamMaas:C}";
            }
            catch
            {
                MessageBox.Show("Lütfen geçerli sayı değerleri girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
