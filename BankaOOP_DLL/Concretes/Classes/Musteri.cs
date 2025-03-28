using BankaOOP_DLL.Abstracts.Classes;

namespace BankaOOP_DLL.Concretes.Classes
{
    // müşteri nesnesi oluşturulmak üzere yazılan class
    public class Musteri : Kisi
    {
        public double Bakiye { get; set; }
        public int KuyrukSiraNo { get; set; } // müşteri kuyruğa girerken alacağı sıra no
        public List<Islem>? Islemler { get; set; } = new List<Islem>(); // müşteri nesnesi oluşturulduğunda bu müşterinin işlemlerine ekleme yapılacağı için aynı anda list de oluşacak. (her müşteri oluşturulduğunda, işlemler listesini oluşturmayı da utility class ında yapmak daha karmaşık olacak)

        public override string ToString()
        {
            return base.ToString() + " - Bakiye : " + Bakiye + " tl";
        }
    }
}