using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_yourself
{
    public class Ogretmen:User 
    {
        public List<Ders> Dersler { get; set; } // ogretmenin dersleri

    }
}
