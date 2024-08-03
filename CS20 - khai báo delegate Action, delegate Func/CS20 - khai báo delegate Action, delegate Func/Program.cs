using System;

// delegate (Type) bien = phuongthuc
namespace CS_Delegate
{
    public delegate void ShowLog(string message);
    class Program
    {
        static void Main(string[] args)
        {
            ShowLog log = null;
            // log = Info;
            // if ( log != null)
            // {
            // log("Xin chao");
            // }

            log += Info;
            log += Info;
            log += Info;

            log += Wanrning;
            log += Wanrning;

            log += Info;


            log?.Invoke("Loaniuoi");

            //log = Wanrning;
            //log("Loanxinhiu"); 

            // Action, Func: delegatr - generic
            Action action;                  // ~delegate void Kieu();
            Action<string, int> action1;    // ~delegate void Kieu(string s, int i);
            Action<string> action2;

            action2 = Wanrning;
            action2 += Info;
            action2?.Invoke("Thong bao tu Action");


            Func<int> f1;                 //~delegate int KIEU();
            Func<string, double, int> f2; //~delegate string KIEU(string s, double s, int s);

            Func<int, int, int> tinhtoan;
            int a = 5, b = 10;
            tinhtoan = Tong;
            Console.WriteLine($"KQ: Tong la {tinhtoan(a,b)}");

            Tich(a, b, Wanrning);

        }

        static int Tong(int a, int b) => a + b;
        static int Hieu(int a, int b) => a - b;
        static void Tich(int a, int b, ShowLog log)
        {
            int kq = a * b;
            log?.Invoke($"Tich la {kq}");
        }
        static void Wanrning (string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
    }
}