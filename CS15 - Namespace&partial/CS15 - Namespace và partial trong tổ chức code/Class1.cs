using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNameSpace
{
    public class class1
    {
        public static void XinChao()
        {
            Console.WriteLine("Xinchao tu class1");
        }
    }

    namespace Abc
    {
        public class class1
        {
            public static void XinChao()
            {
                Console.WriteLine("Xin chao tu Class1 / Abc");
            }
        }
    }
}
