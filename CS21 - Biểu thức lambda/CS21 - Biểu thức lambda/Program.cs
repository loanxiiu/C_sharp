using System;
using System.Linq;

namespace CS_Lambda
{
    /*
     * Lambda - Anonymous function
     *  1. (int a, int b) => bieu_thuc;
     *  2. (tham_so) => {
     *      Cacbieuthuc;
     *      return bieuthuctrave;
     *     }
     */

    class Program
    {
        static void Main(string[] args)
        {
            /* Action<string> thongbao;
            thongbao = (string s) => Console.WriteLine(s); // ~ delegate void KIEU(string s) = Action<string>
            for (int i=0; i<10; i++)
            {
                thongbao?.Invoke("chao Loanxinhiu");
            } */

            /* Action thongbao;
            thongbao = () => Console.WriteLine("Xin chao Loanxinhiu");
            thongbao?.Invoke(); */

            Action<string, int> welcome;
            welcome = (s, i) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(s + i);
                Console.ResetColor();
            };
            welcome?.Invoke("Loaniuoi", 1);

            // bien delegate co kieu tra ve
            Func<int, int, int> tinhtoan;
            tinhtoan = (int a, int b) =>
            {
                int kq = a + b;
                return kq;
            };
            Console.WriteLine(tinhtoan.Invoke(5, 6));

            // su dung lambda trong mot so thu vien .net
            int[] mang = { 1, 3, 4, 2, 6, 7 };
            var kq = mang.Select(
                (int x) =>
                {
                    return Math.Sqrt(x);
                }
            );

            foreach (var result in kq)
            {
                Console.WriteLine(result);
            }

            mang.ToList().ForEach(
                (int x) =>
                {
                    if (x % 2 != 0)
                    {
                        Console.WriteLine(x);
                    }
                }
            );

            var kq2 = mang.Where(
                 (x) =>
                 {
                     return x % 2 == 0;
                 }
            );
            foreach(var n in kq2)
            {
                Console.WriteLine(n);
            }

            /*(int a, int b) =>
            {
                int kq = a + b;
                return kq;
            } */
        }
    }
}