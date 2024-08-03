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
        static void Main(string[] args)
        {
            // Action, Func: delegate - generic
            Action action; // delegate  void KIEU();
            Action<string, int> action1; // delegate void KIEU(string s, int i);

            Action<string> action2; // delegate void KIEU(string s)
            action2 = Warning;
            action2 += Info;
            action2?.Invoke("Loaniuoi");
        }
    }
}