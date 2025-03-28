using BankaOOP_DLL.Concretes.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Abstracts.Classes
{
    // işlemler için ortak özelliklerin yazıldığı abstract class
    public abstract class Islem
    {
        public int IslemId { get; set; }
        public double IslemMiktari { get; set; }
        public DateTime IslemTarihi { get; set; }
        public Musteri? Musteri { get; set; } // Bir veznede aynı anda sadece bir müşteri kabul edilip işlem yapacak.
        public Vezne? Vezne { get; set; }

        public override string ToString()
        {
            return $"{IslemId} - {IslemTarihi} - Müşteri : {Musteri} - {Vezne.ToString()}";
        }
    }
}
