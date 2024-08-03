// delegate (Type) bien = phuong thuc
namespace Delegate
{
    public delegate void ShowLog(string message);
    class Program
    {
        static void Info(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        static void Warning(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        static int Tong(int a, int b) => a + b;
        static void Hieu(int a, int b, ShowLog log)
        {
            int kq = a - b;
            log?.Invoke("Tong la " + kq);
        }

        delegate int KIEU1();
        static void Main(string[] args)
        {
            // Action, Func: delegate - generic
            //KIEU1 f1;
            Func<int> f1; // delegate int KIEU1();
            Func<string, double, string> f2; // delegate string KIEU(string s, double s);

            Func<int, int, int> tinhtoan;
            int a = 5;
            int b = 10;
            tinhtoan = Tong;
            Console.WriteLine(tinhtoan(a, b));
            Hieu(a, b, Info);
        }
    }
}