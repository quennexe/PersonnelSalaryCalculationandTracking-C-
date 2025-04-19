using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace PersonelMaasApp
{
    public class FormPersonelEkle : Form
    {
        TextBox txtAd, txtSoyad, txtTC, txtGorev;
        DateTimePicker dtGirisTarihi;
        Button btnEkle;

        public FormPersonelEkle()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Yeni Personel Ekle";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblAd = new Label() { Text = "Ad:", Location = new Point(30, 30), AutoSize = true };
            txtAd = new TextBox() { Location = new Point(120, 30), Width = 200 };

            Label lblSoyad = new Label() { Text = "Soyad:", Location = new Point(30, 70), AutoSize = true };
            txtSoyad = new TextBox() { Location = new Point(120, 70), Width = 200 };

            Label lblTC = new Label() { Text = "TC No:", Location = new Point(30, 110), AutoSize = true };
            txtTC = new TextBox() { Location = new Point(120, 110), Width = 200 };

            Label lblGorev = new Label() { Text = "Görev:", Location = new Point(30, 150), AutoSize = true };
            txtGorev = new TextBox() { Location = new Point(120, 150), Width = 200 };

            Label lblGirisTarihi = new Label() { Text = "Giriş Tarihi:", Location = new Point(30, 190), AutoSize = true };
            dtGirisTarihi = new DateTimePicker() { Location = new Point(120, 190), Width = 200 };

            btnEkle = new Button() { Text = "EKLE", Location = new Point(120, 240), Width = 100 };
            btnEkle.Click += BtnEkle_Click;

            this.Controls.AddRange(new Control[] 
            { 
                lblAd, txtAd, 
                lblSoyad, txtSoyad, 
                lblTC, txtTC, 
                lblGorev, txtGorev, 
                lblGirisTarihi, dtGirisTarihi, 
                btnEkle 
            });
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string tc = txtTC.Text;
            string gorev = txtGorev.Text;
            string girisTarihi = dtGirisTarihi.Value.ToShortDateString();

            if (ad == "" || soyad == "" || tc == "" || gorev == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

          
            Personel yeniPersonel = new Personel
            {
                Ad = ad,
                Soyad = soyad,
                TC = tc,
                Gorev = gorev,
                GirisTarihi = girisTarihi
            };

            // Personel bilgilerini JSON dosyasına kaydet
            string jsonDosyasi = "personel.json";
            string jsonData = JsonConvert.SerializeObject(yeniPersonel, Formatting.Indented);

            // Dosyaya yazma işlemi
            if (File.Exists(jsonDosyasi))
            {
                // Dosya varsa veriyi ekle
                File.AppendAllText(jsonDosyasi, jsonData + Environment.NewLine);
            }
            else
            {
                // Dosya yoksa yeni dosya oluştur
                File.WriteAllText(jsonDosyasi, jsonData + Environment.NewLine);
            }

           
            MessageBox.Show("Personel başarıyla eklendi!");

            
            this.Close();
        }
    }

    // Personel sınıfı
    public class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Gorev { get; set; }
        public string GirisTarihi { get; set; }
    }
}
