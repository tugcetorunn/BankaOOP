using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Abstracts.Classes
{
    // tüm kişiler (personeller + müşteriler) için oluşturulan abstract class
    public abstract class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Ad} {Soyad}";
        }
    }
}
