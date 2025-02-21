using System.Linq.Expressions;

namespace HataYonetimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C#’ta Hata Türleri
            //C# programlarında hatalar genellikle 3 ana kategoride sınıflandırılır: Derleme Zamanı Hataları (Compile-time errors), Çalışma Zamanı Hataları (Runtime errors) ve Semantik Hatalar (Semantic errors).

            #region Derleme Zamanı Hataları
            //1-Derleme Zamanı Hataları (Compile Exception)
            //Derleme zamanı hataları, derleyici tarafından kodunuzu derlerken (yani programı çalıştırmadan önce) tespit edilen hatalardır. Bu hatalar genellikle sözdizimi (syntax) hatalarıdır ve programın çalışmaya başlamadan önce düzeltilmesi gerekir.

            //Örnek 1- Değişken Tanımlama Hataları:
            //Bir değişkeni kullanmadan önce tanımlamamak derleme hatasına yol açar.
            int x;
            Console.WriteLine(x); //Hata: x değişkenine henüz değer atanmadı.

            //Örnek 2- Söz Dizimi Hataları:
            //Kod yazım hataları derleme hatası oluşturur.
            if (x == 5) ;  //Hata: Parantez eksik.

            //Örnek 3- Uygunsuz Türer(Type Mismatch):
            //Bir veri türü ile uyumsuz işlemler yapılması da derleme hatasına yol açar.
            string a = "5";
            int b = a; //Hata: string türü int türüne atanamaz.
            #endregion

            #region Çalışma Zamanı Hataları
            //2-Çalışma Zamanı Hataları (Runtime Errors)
            //Çalışma zamanı hataları, programın çalışmaya başlamasıyla çalışan ancak koşullar altında oluşan hatalardır. Derleyici bu hataları tespit edemez çünkü bu hatalar program çalışırken ortaya çıkar.

            //Örnek 1- Sıfıra Bölme (Divide by Zero):
            //Bir sayıyı sıfıra bölmeye çalışmak çalışma zamanı hatasına yol açar.
            int c = 10;
            int d = 0;
            Console.WriteLine(c / d); //Hata: Sayı sıfıra bölünemez.

            //Örnek 2- Dizi Sınırları Dışı (Array Index Out of Bounds):
            //Dizinin sınırları dışına çıkmak da çalışma zamanı hatasıdır.
            int[] sayilar = { 1, 2, 3, 4 };
            Console.WriteLine(sayilar[5]); //Hata: Geçersiz dizi erişimi

            //Örnek 3- Null Referans (Null Reference Exception):
            //Bir nesneye null (boş) değer atandıysa ve bu nesneye erişmeye çalışıyorsanız, bu çalışma zamanı hatası oluşur.
            string str = null;
            Console.WriteLine(str.Length); //Hata: null nesnesine erişim

            //Çalışma Zamanı Hatalarının Çözümü:
            //Hata kontrolü (Exception handling) kullanarak hata olasılıklarını kontrol edin.
            //Kullanıcıdan alınan verilerin geçerliliğini kontrol edin (örneğin sıfıra bölme).
            //null değerlerle çalışırken dikkatli olun.
            #endregion

            #region Semantic Hatalar 
            //3-Semantik Hatalar (Semantic Errors)
            //Semantik hatalar, sözdizimi açısından doğru ancak mantıksal olarak yanlış olan hatalardır. Bu hatalar, kodun doğru şekilde çalışmasına engel olmaz, ancak istenmeyen sonuçlara yol açar.

            //Örnek 1- Yanlış Hesaplama:
            //Kod doğru şekilde derlenebilir ve çalıştırılabilir, ancak mantıksal hata nedeniyle yanlış sonuçlar üretir.
            int sayi1 = 10;
            int sayi2 = 5;
            int sonuc = sayi1 - sayi2; //Beklenmeyen sonuç, kullanıcı aslında toplama yapmak istiyor.

            //Örnek 2- Yanlış Karar Yapısı:
            //Hatalı koşul ifadeleri mantıksal hata oluşturabilir.
            int z = 10;
            int y = 5;

            if (z < y)
            {
                Console.WriteLine("z, y'den büyük"); //Hata: z,y den büyükse küçüktür mesajı verir.
            }
            else
            {
                Console.WriteLine("z, y'den küçük");
            }
            #endregion

            //C#’ta Hata Yönetimi (Exception Handling)
            //Hata yönetimi, programın beklenmeyen durumlarla karşılaştığında cokmesini engellemek ve kullanıcıya anlamlı mesajlar vermek için kullanılan bir tekniktir. C# dilinde hata yonetimi için try - catch - finally - throw yapıları kullanılır.

            #region try-catch Yapısı
            //Temel Kullanım
            try
            {
                //Hata oluşabilecek kodlar buraya yazılır.
            }
            catch (Exception ex)
            {
                //Try bloğu içerisinde yazmış olduğumuz kodlarda herhangi bir hata meydana gelirse,catch bloğu devreye girer.
                Console.WriteLine("Hata: " + ex.Message);
            }

            //Örnek 1- Sıfıra bölme hatası yakalama
            try
            {
                int sayi3 = 10, sayi5 = 0;
                int bolme = sayi3 / sayi5;
            }
            catch (DivideByZeroException ex)  //Sıfıra bölme hatasını yakalar.
            {
                Console.WriteLine("Matematiksel Hata: " + ex.Message);
            }

            //Örnek 2-Format Hatası ve Aşım Hatası
            try
            {
                Console.Write("Bir tam sayı girin: ");
                int sayi = Convert.ToInt32(Console.ReadLine());  // Kullanıcı yanlış veri girerse hata oluşur.
                Console.WriteLine("Girdiğiniz sayı: " + sayi);
            }
            catch (FormatException) //Girilen değerin beklenen formatta olmaması durumunda oluşur.
            {
                Console.WriteLine("Lütfen sadece tam sayı giriniz!");
            }
            catch (OverflowException) //Girilen sayının int sınırlarını aşması durumunda oluşur.
            {
                Console.WriteLine("Çok büyük veya çok küçük bir sayı girdiniz!");
            }

            //Çıktı: Bir tam sayı girin: abc
            //Lütfen sadece tam sayı giriniz!
            #endregion

            #region try-catch-finally Kullanımı
            //Temel Kullanım: finally bloğu, hata oluşsa da oluşmasa da her durumda çalışır. Genellikle veritabanı bağlantıları, dosya işlemleri gibi kaynakları serbest bırakmak için kullanılır.
            try
            {
                //Hata olmadığı durumda çalışacak kodlar
            }
            catch (Exception)
            {
                //Hata olduğu durumda çalışır.
            }
            finally
            {
                //Her iki durumda da çalışır.
            }

            //Örnek 1:
            try
            {
                int[] sayilarDizisi = { 1, 2, 3, };
                Console.WriteLine(sayilar[5]);   //Dizi sınırlarının dışına çıkma hatası verir.
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Dizinin sınırları dışında bir indekse erişmeye çalıştınız.");
            }
            finally
            {
                Console.WriteLine("Hata Yönetimi tamamlandı.");
            }

            //Çıktı: 
            //Dizinin sınırları dışında bir indekse erişmeye çalıştınız.
            //Hata yönetimi tamamlandı.
            #endregion

            #region Multiple Catch (Birden Fazla catch Kullanımı)
            //Eğer farklı hata türleri için farklı işlemler yapmak istiyorsak, birden fazla catch bloğu kullanabiliriz.

            //Örnek 1:
            try
            {
                string veri = null;
                Console.WriteLine(veri.Length); // Null Reference Exception hatası
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Null referans hatası oluştu: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Genel bir hata oluştu: " + ex.Message);
            }

            //Çıktı:
            //Null referans hatası oluştu: Object reference not setto an instance of an object.

            #endregion

            #region throw Kullanımı (Özel Hata Fırlatma)
            //Bazı durumlarda kendi özel hatamızı oluşturup fırlatmak isteyebiliriz. Bilinçli bir şekilde hata fırlatırız.

            //Örnek 1-Negatif sayılar için özel hata fırlatma
            static void SayiyiKontrolEt(int sayi)
            {
                if (sayi < 0)
                {
                    throw new ArgumentException("Sayı negatif olamaz!"); //ArgumentException nesnesi oluşturulup fırlatılıyor.
                }
                else
                {
                    Console.WriteLine("Girilen sayı: " + sayi);
                }
            }

            try
            {
                SayiyiKontrolEt(-5); // Negatif sayı göndererek hata oluşturuyoruz.
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
            }

            //Çıktı: Hata: Sayı negatif olamaz!
            #endregion

            #region Hata oluşturma
            //Özel bir istisna (exception) sınıfı oluşturmak için yazılır.

            //OzelHataMesaji sınıfı, Exception sınıfından türetilmiş bir özel hata sınıfıdır.

            //Ornek 1:
            try
            {
                throw new OzelHataMesaji(); // Özel hatayı fırlatıyoruz
            }
            catch (OzelHataMesaji ex)
            {
                Console.WriteLine("Hata yakalandı: " + ex.Message);
            }
            #endregion

            #region Genel Ornek
            try
            {
                Console.WriteLine("Telefon numarası: ");
                int gelenDeger = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Tebrikler! Doğru Telefon Numarası Girdiniz");
            }
            catch (FormatException hata) //Format hata tipi String to int
            {
                Console.WriteLine(hata.Message);
            }
            catch (OverflowException hata) //Veri tipinin boyutunu aşması durumunda hata tipi.
            {
                Console.WriteLine(hata.Message);
            }
            catch (DivideByZeroException hata) //Sıfıra bölünme hatası
            {
                Console.WriteLine(hata.Message);
            }
            catch (IndexOutOfRangeException ex) // Dizi sınırlarının dışına çıkma hatası
            {
                Console.WriteLine("Dizinin sınırları dışında bir indekse erişmeye çalıştınız.");
            }
            catch (OzelHataMesaji ex) //Benim olusturdugum hata fırlatıldı.
            {
                Console.WriteLine("Benim oluşturduğum hata çalıştı. " + ex.Message);
            }
            catch (Exception hata)
            {
                Console.WriteLine(hata.Message);
            }
            finally
            {
                Console.WriteLine("Başarılı olsa da olmasa da buraya uğra");  //Hata olsa da olmasa da çalışmasını istediğimiz kodları yazdığımız alandır.
            }
            #endregion
        }
    }
}
