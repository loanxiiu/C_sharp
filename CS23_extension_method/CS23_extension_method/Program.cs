using System;
using System.Linq;
using MyLib;

namespace CS_ExtensionMethod
{
    // extension method
    // lop tinh static
    static class Abc
    {
        public static void Print(this string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            /* int[] mang = { 1, 2, 3, 7, 4 };
            int max = mang.Max();
            Console.WriteLine(max);*/

            string s = "Xin chao Loaniuoi";
            /* Print(s, ConsoleColor.Green);
            Print(s, ConsoleColor.Red); */

            /* s.Print(ConsoleColor.Yellow);
            "Loaniuoi".Print(ConsoleColor.Cyan); */

            double a = 2.5;
            Console.WriteLine(a.BinhPhuong());
        }
        /* public static void Print(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        } */
    }

}