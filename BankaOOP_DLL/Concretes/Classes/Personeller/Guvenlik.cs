using BankaOOP_DLL.Abstracts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes.Personeller
{
    // güvenlik nesnesi oluşturulmak üzere yazılan class
    public class Guvenlik : Personel
    {
        public override string ToString()
        {
            return base.ToString() + " - Görevi : " + typeof(Guvenlik).Name;
        }
    }
}
