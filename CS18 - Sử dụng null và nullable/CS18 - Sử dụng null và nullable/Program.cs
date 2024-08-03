using System;
using System.Threading.Tasks.Dataflow;

namespace CS10
{
    class Abc
    {
        public void XinChao() => Console.WriteLine("Xin chao C#");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Abc a = new Abc();
            /* if( a!= null)
            a.XinChao(); */
            a?.XinChao();

            // Khai bao bien kieu tham tri co kha nang nhan gia tri null
            int? age; 
            age = null;
            age = 10;
            if (age.HasValue)
            {
                //int _age = age.Value;
                int _age = (int)age;
                Console.WriteLine(_age);
            }
        }
    }
}