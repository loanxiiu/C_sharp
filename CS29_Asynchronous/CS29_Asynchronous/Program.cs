namespace async_await
{
    class Program
    {
        static  void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs,10}... Star");
            Console.ResetColor();

            for (int i = 0; i < seconds; i++)
            {
                // Khóa truy cập tới đối tượng với từ lock
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Console.ResetColor();
                }
                Thread.Sleep(5000);
            }
            Console.ForegroundColor = color;
            Console.WriteLine($"{mgs,10}... End");
            Console.ResetColor();
        }

        // asynchronous (multi thread)
        static void Main(string[] args)
        {
            DoSomeThing(5, "fdg", ConsoleColor.Red);
            Console.WriteLine("Hello world!");

        }
    }
}