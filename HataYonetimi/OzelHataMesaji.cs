using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HataYonetimi
{
    public class OzelHataMesaji : Exception
    {
        // Hata mesajını Exception sınıfına aktarıyoruz
        public OzelHataMesaji() : base("Özel hatayla karşılaşıldı.")
        {
            // Console.WriteLine yerine base() kullanıldı.
        }
    }
}
