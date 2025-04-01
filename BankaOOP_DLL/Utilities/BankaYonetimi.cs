using BankaOOP_DLL.Abstracts.Classes;
using BankaOOP_DLL.Concretes.Classes;
using BankaOOP_DLL.Concretes.Classes.Islemler;
using BankaOOP_DLL.Concretes.Classes.Personeller;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BankaOOP_DLL.Utilities
{
    // banka ve diğer class ların instance larını oluşturma metodlarını bir class altında yazıp daha sonra sadece çağıracağız. (clean code, yönetilebilirlik, platform bağımsızlığı için)
    public static class BankaYonetimi
    {
        static Random rnd = new Random();
        private static List<string> adlar = new() { "Kemal", "Hande", "Nazlı", "Gaye", "Hakan", "Yaşar" };
        private static List<string> soyadlar = new() { "Kemik", "Hare", "Dere", "Deniz", "Dağ", "Tan" };
        static Kuyruk kuyruk = new Kuyruk();
        private static int vezneSirasi = 0; // vezneleri sıra sıra gezebilmek için sıra no atandı

        private static string AdOlustur(List<string> liste)
        {
            return liste[rnd.Next(liste.Count - 1)];
        }

        public static void DosyayaYaz<T>(string dosyaAdi, List<T> entity)
        {
            string json = JsonConvert.SerializeObject(entity, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            File.WriteAllText(dosyaAdi, json);
        }

        public static void BankayiDoldur(Banka banka)
        {
            // veznedarları oluşturma ve bankaya atama
            for (int i = 0; i < 2; i++)
            {
                banka.Personeller.Add(new Veznedar() { Id = rnd.Next(1000, 2000), Ad = AdOlustur(adlar), Soyad = AdOlustur(soyadlar) });
            }

            // vezneleri oluşturma ve bankaya atama
            for (int i = 0; i < banka.Vezneler.Capacity; i++)
            {
                banka.Vezneler.Add(new Vezne() { VezneId = i + 1, Veznedar = (Veznedar)banka.Personeller[i] });
            }

            // diğer personelleri oluşturma ve bankaya atama
            banka.Personeller.Add(new Mudur { Id = rnd.Next(1000, 2000), Ad = AdOlustur(adlar), Soyad = AdOlustur(soyadlar) });
            banka.Personeller.Add(new Guvenlik { Id = rnd.Next(1000, 2000), Ad = AdOlustur(adlar), Soyad = AdOlustur(soyadlar) });
            banka.Personeller.Add(new Hizmetli { Id = rnd.Next(1000, 2000), Ad = AdOlustur(adlar), Soyad = AdOlustur(soyadlar) });

            // bankaya kuyruk nesnesini ekleme
            banka.Kuyruk = kuyruk;
        }

        public static List<Musteri> MusteriOlustur(int musteriSayisi)
        {
            // parametrerde belirtilen sayıda müşteri random değerlerle oluşturulacak
            List<Musteri> musteriler = new List<Musteri>();

            for (int i = 0; i < musteriSayisi; i++)
            {
                musteriler.Add(new Musteri { Id = i + 1, Ad = AdOlustur(adlar), Soyad = AdOlustur(soyadlar), Bakiye = rnd.Next(1, 50000) });
            }

            return musteriler;
        }

        public static void KuyrugaAlma(List<Musteri> musteriler, Banka banka)
        {
            int sira = 1;
            // müşterileri kuyruğa alma
            foreach (var musteri in musteriler)
            {
                banka.Kuyruk.Musteriler.Add(musteri);
                musteri.KuyrukSiraNo = sira;
                sira++;
            }
            
        }
        public static void IslemYap(Musteri musteri, Banka banka)
        {
            var vezne = banka.Vezneler[vezneSirasi];
            vezneSirasi = (vezneSirasi + 1) % banka.Vezneler.Count;

            int sayi = rnd.Next(1, 4); // rastgele işlem atama için
            Islem islem;

            if (sayi == 1)
            {
                islem = new Havale() { IslemId = rnd.Next(2000, 3000), IslemMiktari = rnd.Next(1, 50000), GonderilecekIBAN = rnd.Next(10000000, 100000000).ToString(), IslemTarihi = DateTime.Now.AddDays(rnd.Next(1, 20) * (-1)), Musteri = musteri, Vezne = vezne };
            }
            else if (sayi == 2)
            {
                islem = new ParaYatirma() { IslemId = rnd.Next(2000, 3000), IslemMiktari = rnd.Next(1, 50000), IslemTarihi = DateTime.Now.AddDays(rnd.Next(1, 20) * (-1)), Musteri = musteri, Vezne = vezne };
            }
            else
            {
                islem = new ParaCekme() { IslemId = rnd.Next(2000, 3000), IslemMiktari = rnd.Next(1, 50000), IslemTarihi = DateTime.Now.AddDays(rnd.Next(1, 20) * (-1)), Musteri = musteri, Vezne = vezne };
            }

            // vezne.Islemler.Add(islem); // json dosyada veznedardan da işlemler sıralandığı için burası yorum satırına alındı.
            musteri.Islemler.Add(islem);
        }

    }
}
