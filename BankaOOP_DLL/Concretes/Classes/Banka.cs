using BankaOOP_DLL.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes
{
    public class Banka
    {
        // banka nesnesi oluşturulmak üzere yazılan class
        public Banka()
        {
            Vezneler = new List<Vezne>(2); // banka nesnesi oluşturulduğu anda 2 vezne için list oluşturacak
            Personeller = new List<Personel>(5); // banka nesnesi oluşturulduğu anda 5 personel için list oluşturacak
            // Musteriler = new List<Musteri>(); // banka nesnesi oluşturulduğu anda müşteriler için list oluşturacak
        }
        public int BankaId { get; set; }
        public string BankaAdi { get; set; }
        public List<Vezne>? Vezneler { get; set; }
        public List<Personel>? Personeller { get; set; }
        public Kuyruk Kuyruk { get; set; }

        // public List<Musteri>? Musteriler { get; set; }

        public override string ToString()
        {
            return $"{BankaId} - {BankaAdi}";
        }
    }
}
