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
        // Asynchronous
        // Task
        // Task t2 = new Task(Action); // () => {}
        Task t2 = new Task(
            () =>{
                DoSomeThing(5, "T2", ConsoleColor.Green);
            }
        );

        // Task t3 = new Task(Action<object>, object); // (Object ob) => {}
        Task t3 = new Task(
            (object ob) =>
            {
                string tentacvu = (string)ob;
                DoSomeThing(7, tentacvu, ConsoleColor.Yellow);
            }
        , "T3");

        t2.Start(); // Thread
        t3.Start(); // Thread

        DoSomeThing(6, "T1", ConsoleColor.Magenta); // Task chính

        //t2.Wait();
        //t3.Wait();
        Task.WaitAll(t2,t3);

        Console.WriteLine("Press any key");
        Console.ReadKey();
    }
}