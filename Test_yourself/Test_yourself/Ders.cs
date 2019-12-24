using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_yourself
{
    public class Ders
    {
        public string DersIsmi { get; set; }
        public string DersinHocasi { get; set; }
        List<Soru> soruHavuzu { get; set; }
        List<string> dersinKonulari { get; set; }// ogretmen ders yaratinca her sorunun konusu en az bir kez yazilir ogrenci ders alinca calismasi gerekene birer kez eklenir
    }
}
