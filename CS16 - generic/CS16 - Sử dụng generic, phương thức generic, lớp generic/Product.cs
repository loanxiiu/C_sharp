using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS16___Sử_dụng_generic__phương_thức_generic__lớp_generic
{
    internal class Product <A>
    {
        A ID;
        public void SetID(A _id)
        {
            this.ID = _id;
        }

        public void PrintTnf()
        {
            Console.WriteLine($"ID = {this.ID}");
        }
    }
}
