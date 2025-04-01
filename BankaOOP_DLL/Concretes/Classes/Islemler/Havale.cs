using BankaOOP_DLL.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes.Islemler
{
    // havale işlemi nesnesi oluşturulmak üzere yazılan class
    public class Havale : Islem
    {
        private double havaleMiktari;
        public double HavaleMiktari
        {
            get
            {
                return havaleMiktari;
            }
            set
            {
                if (havaleMiktari > Musteri.Bakiye)
                {
                    havaleMiktari = 0;
                }
                else
                {
                    havaleMiktari = value;
                    Musteri.Bakiye -= havaleMiktari;
                }
            }
        }
        public Havale()
        {
            IslemTipi = this.GetType().Name;
        }

        public string GonderilecekIBAN { get; set; }

        public override void IslemYap(Musteri musteri)
        {
            if (musteri.Bakiye < IslemMiktari)
            {
                // bir şey yapma
            }
            else
            {
                musteri.Bakiye -= IslemMiktari;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " İşlem Tipi: " + this.GetType().Name;
        }
    }
}
