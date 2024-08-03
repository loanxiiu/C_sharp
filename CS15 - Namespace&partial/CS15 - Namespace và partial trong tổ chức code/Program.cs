using MyNameSpace;
using XYZ = MyNameSpace.Abc;
using static System.Console;
using static System.Math;

namespace ns_example
{
    class Program
    {
        static void Main(string[] args)
        {
            class1.XinChao();
            XYZ.class1.XinChao();
            WriteLine("Loaniuoi");
            WriteLine(PI);

            Sanpham.Product product = new Sanpham.Product();
            product.name = "Ipad";
            product.price = 10000;
            product.description = "day la may cua Loaniuoi";
            WriteLine(product.GetInfo());

            product.manufactory = new Sanpham.Product.Manufactory();
            product.manufactory.name = "Apple";
            product.manufactory.addr = "USA";
            WriteLine(product.Info());
        }
    }
}