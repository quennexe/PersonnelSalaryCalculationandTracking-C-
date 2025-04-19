using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PersonelMaasApp.Models;

namespace PersonelMaasApp.Utils
{
    public static class PersonelData
    {
        private static readonly string dosyaYolu = "personeller.json";

        public static void PersonelEkle(Personel personel)
        {
            List<Personel> mevcutListe = PersonelListesiGetir();
            mevcutListe.Add(personel);

            string json = JsonConvert.SerializeObject(mevcutListe, Formatting.Indented);
            File.WriteAllText(dosyaYolu, json);
        }

        public static List<Personel> PersonelListesiGetir()
        {
            if (!File.Exists(dosyaYolu))
                return new List<Personel>();

            string json = File.ReadAllText(dosyaYolu);
            return JsonConvert.DeserializeObject<List<Personel>>(json) ?? new List<Personel>();
        }
    }
}
