using BankaOOP_DLL.Concretes.Classes;
using BankaOOP_DLL.Utilities;

// banka oluşturma ve bankayı doldurma işlemleri
Banka banka = new Banka() { BankaId = 1, BankaAdi = "Halkbank"};

BankaYonetimi.BankayiDoldur(banka);

// banka personellerini console a yazdırma
Console.WriteLine("Banka personelleri ve görevleri : ");
foreach (var personel in banka.Personeller)
{
    Console.WriteLine(personel.ToString());
}

// program çalıştığında rastgele oluşacak müşteriler metodunu çalıştırma
var musteriler = BankaYonetimi.MusteriOlustur(10);

// müşterileri sırayla kuyruğa alma
BankaYonetimi.KuyrugaAlma(musteriler, banka);

// kuyruktaki kişilere rastgele işlem yapma ve console a yazdırma
Console.WriteLine("İşlemler : ");
foreach (var musteri in banka.Kuyruk.Musteriler)
{
    // her müşteri dolaşılırken rastgele işlem atayan metodu çalıştırıyoruz. sırayla işlem atanıyor.
    BankaYonetimi.IslemYap(musteri, banka);
    foreach (var islem in musteri.Islemler)
    {
        Console.WriteLine(islem.ToString());
    }
}

// json olarak kaydetme
BankaYonetimi.DosyayaYaz("islemlerVeMusteriler.json", musteriler);

foreach (var musteri in banka.Kuyruk.Musteriler)
{
    foreach (var islem in musteri.Islemler)
    {
        Console.WriteLine(islem.ToString());
    }
}

Console.WriteLine();
