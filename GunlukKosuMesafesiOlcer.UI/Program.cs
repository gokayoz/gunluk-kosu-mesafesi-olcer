namespace GunlukKosuMesafesiOlcer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("  Günlük Koşu Mesafesi Hesaplama Uygulaması");
            Console.WriteLine("===========================================");
            Console.WriteLine("Hoş Geldiniz! Koşu mesafenizi hesaplamak için bilgilerinizi girin.\n");

            bool devamMi = true;
            while (devamMi)
            {
                KosuMesafesiHesapla();
                devamMi = HesaplamaDevamMi();
            }
            Console.WriteLine("\nTeşekkürler! Uygulamayı kullandığınız için memnun olduk.");
        }
        static bool GirilenSayiMi(string strSayi, out int sayi)
        {
            return int.TryParse(strSayi, out sayi) && sayi > 0;
        }
        static int SayiAl(string mesaj)
        {
            int sayi;
            string strSayi;
            do
            {
                Console.Write(mesaj);
                strSayi = Console.ReadLine();
                bool sayiMi = GirilenSayiMi(strSayi, out sayi);
                if (!sayiMi)
                {
                    Console.WriteLine("Lütfen geçerli bir pozitif sayı giriniz!");
                }
            } while (!GirilenSayiMi(strSayi, out sayi));
            return sayi;
        }
        static int KosuBolumSayisiAl()
        {
            return SayiAl("Koşu kaç bölümden oluşacak? (Örnek: 3): ");
        }
        static (int adim, int sure) BolumBilgisiAl(int bolumNumarasi)
        {
            int adim = SayiAl($"Koşunun {bolumNumarasi}. bölümü için dakikada kaç adım attığınızı giriniz: ");
            int sure = SayiAl($"Koşunun {bolumNumarasi}. bölümü için süreyi giriniz (dakika cinsinden): ");
            return (adim, sure);
        }
        static int OrtalamaBirAdimAl()
        {
            return SayiAl("Lütfen ortalama bir adımınızı santimetre cinsinden giriniz (Örnek: 70): ");
        }
        static float KosuMesafesiHesapla()
        {
            int bolumSayisi = KosuBolumSayisiAl();
            int adimUzunlugu = OrtalamaBirAdimAl();
            int toplamAdimSayisi = 0;

            for (int i = 1; i <= bolumSayisi; i++)
            {
                var (adim, sure) = BolumBilgisiAl(i);
                toplamAdimSayisi += adim * sure;
            }

            float toplamKosuMesafesi = (adimUzunlugu * toplamAdimSayisi) / 100f;
            Console.WriteLine($"\nToplam koşu mesafeniz: {toplamKosuMesafesi} metre.");
            return toplamKosuMesafesi;
        }
        static bool HesaplamaDevamMi()
        {
            Console.WriteLine("\nTekrar hesaplama yapmak istiyorsanız herhangi bir tuşa basın. Çıkmak için 'evet' yazın.");
            string cikisYap = Console.ReadLine().ToLower().Trim();
            return cikisYap != "evet";
        }
    }
}
