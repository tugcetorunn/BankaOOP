using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankaOOP_DLL.Concretes.Classes
{
    // bankaya gelen müşterilerin işlem yapmadan önce girdikleri işlem sırası
    public class Kuyruk
    {
        public List<Musteri> Musteriler { get; set; } = new List<Musteri>();
    }
}
