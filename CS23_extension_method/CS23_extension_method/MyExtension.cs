using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public static class Xyz 
    {
        public static double BinhPhuong(this double x) => x * x;
        public static double CanBac2(this double x) => Math.Sqrt(x);
    }
}
