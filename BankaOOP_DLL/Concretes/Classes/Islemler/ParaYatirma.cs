using BankaOOP_DLL.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes.Islemler
{
    // para yatırma işlemi nesnesi oluşturulmak üzere yazılan class
    public class ParaYatirma : Islem
    {
        public ParaYatirma()
        {
            IslemTipi = this.GetType().Name;
        }

        public override void IslemYap(Musteri musteri)
        {
            musteri.Bakiye += IslemMiktari;
        }

        public override string ToString()
        {
            return base.ToString() + " İşlem Tipi: " + this.GetType().Name;
        }
    }
}
