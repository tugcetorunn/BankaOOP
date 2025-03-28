using BankaOOP_DLL.Abstracts.Classes;
using BankaOOP_DLL.Abstracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes.Personeller
{
    // müdür nesnesi oluşturulmak üzere yazılan class
    public class Mudur : Personel, IVeznedeOturabilir
    {
        public override string ToString()
        {
            return base.ToString() + " - Görevi : " + typeof(Mudur).Name;
        }
    }
}
