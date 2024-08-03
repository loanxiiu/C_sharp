using CS16___Sử_dụng_generic__phương_thức_generic__lớp_generic;
using System;
namespace generic_example
{
    class Program
    {
        static void Swap<T>(ref T x, ref T y)
        {
            T t = x;
            x = y;
            y = t;
        }
        static void Main(string[] args)
        {
            int a = 5;
            int b = 45;
            Swap<int>(ref a, ref b);
            Console.WriteLine($"a: {a}, b: {b}");

            Product<int> sanpham1 = new Product<int>();
            sanpham1.SetID(123);
            sanpham1.PrintTnf();

            Product<string> sanpham2 = new Product<string>();
            sanpham2.SetID("Loaniuoi");
            sanpham2.PrintTnf();

            // Lớp kiểu generic biểu diễn danh sách các phần tử
            List<int> list1 = new List<int>();
            Stack<int> stack;
            Queue<int> queue;
        }
    }
}