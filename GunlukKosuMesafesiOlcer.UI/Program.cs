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

        static int OrtalamaBirAdimAl()
        {
            return SayiAl("Lütfen ortalama bir adımınızı santimetre cinsinden giriniz (Örnek: 70): ");
        }

        static int DakikadaKosulanAdimAl()
        {
            return SayiAl("Lütfen dakikada kaç adım koştuğunuzu giriniz (Örnek: 160): ");
        }

        static int KosuSuresiAl()
        {
            Console.WriteLine("Koşu sürenizi giriniz (saat ve dakika olarak).");
            int kosuSaati = SayiAl("Saat: ");
            int kosuDakikasi = SayiAl("Dakika: ");
            return (kosuSaati * 60) + kosuDakikasi;
        }

        static int ToplamAdimSayisiHesapla()
        {
            return DakikadaKosulanAdimAl() * KosuSuresiAl();
        }

        static float KosuMesafesiHesapla()
        {
            float toplamKosuMesafesi = (OrtalamaBirAdimAl() * ToplamAdimSayisiHesapla()) / 100f;
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
