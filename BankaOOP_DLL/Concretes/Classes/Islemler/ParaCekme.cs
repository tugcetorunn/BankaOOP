using BankaOOP_DLL.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes.Islemler
{
    // para çekme işlemi nesnesi oluşturulmak üzere yazılan class
    public class ParaCekme : Islem
    {
        private double paraCekmeMiktari;
        public double ParaCekmeMiktari
        {
            get
            {
                return paraCekmeMiktari;
            }
            set
            {
                if (paraCekmeMiktari > Musteri.Bakiye)
                {
                    paraCekmeMiktari = 0;
                }
                else
                {
                    paraCekmeMiktari = value;
                    Musteri.Bakiye -= paraCekmeMiktari;
                }
            }
        }
        public ParaCekme()
        {
            IslemTipi = this.GetType().Name;

        }

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
