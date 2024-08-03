internal class Program
{
    static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
    {
        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs,10}... Star");
            Console.ResetColor();
        }

        for (int i = 0; i < seconds; i++)
        {
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} {i,2}");
                Console.ResetColor();
            }
            Thread.Sleep(1000);
        }
        lock (Console.Out)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs,10}... End");
            Console.ResetColor();
        }
    }
    private static void Main(string[] args)
    {
        // Synchronous
        DoSomeThing(2, "T1", ConsoleColor.Magenta);
        DoSomeThing(2, "T2", ConsoleColor.Green);
        DoSomeThing(2, "T3", ConsoleColor.Yellow);
        Console.WriteLine("Hello, World!");
    }
}