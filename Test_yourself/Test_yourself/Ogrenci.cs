using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_yourself
{
    public class Ogrenci:User
    {  
        public List<string> CalsimasiGerekenKonular { get; set; } //bir konu 2 kere varsa daha cok calismasi gerekir demek
        public List<Ogretmen> DersiniAldigiOgretmenler { get; set; }//denizhoca.yapayzekaDersi gibi
        public DateTime DersCalismis { get; set; }
        public int ToplamHataSayisi { get; set; }
        public int ToplamSoruCozmus { get; set; }
        //dogru cozme orani ve butun sorulari bitirme oranlari yukaridaki 2 sayilardan hesaplanir
        public List<string> GecmisSinavSoncLarMesajlari { get; set; }//onceki sinavlarim

    }
}
