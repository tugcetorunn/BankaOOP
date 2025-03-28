using BankaOOP_DLL.Abstracts.Classes;
using BankaOOP_DLL.Concretes.Classes.Personeller;

namespace BankaOOP_DLL.Concretes.Classes
{
    // vezne nesnesi oluşturulmak üzere yazılan class
    public class Vezne
    {
        public int VezneId { get; set; }
        public Veznedar? Veznedar { get; set; }
        public List<Islem> Islemler { get; set; } = new List<Islem>();

        public override string ToString()
        {
            return $"VezneId : {VezneId} - Veznedar : {Veznedar.Ad} {Veznedar.Soyad}";
        }
    }
}