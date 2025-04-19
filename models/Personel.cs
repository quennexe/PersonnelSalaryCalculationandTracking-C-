using System;

namespace PersonelMaasApp.Models
{
    public class Personel
    {
        public string AdSoyad { get; set; }
        public string Departman { get; set; }
        public decimal GunlukUcret { get; set; }
        public int GunSayisi { get; set; }
        public decimal Prim { get; set; }
        public DateTime KayitTarihi { get; set; }

        public decimal Maas => (GunlukUcret * GunSayisi) + Prim;
    }
}
