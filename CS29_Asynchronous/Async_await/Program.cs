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

    static async Task Task2()
    {
        Task t2 = new Task(
            () =>
            {
                DoSomeThing(5, "T2", ConsoleColor.Green);
            }
        );
        t2.Start();

        //t2.Wait();
        await t2;
        Console.WriteLine("T2 finished");

        //return t2;
    }

    static async Task Task3()
    {
        Task t3 = new Task(
          (object ob) =>
          {
              string tentacvu = (string)ob;
              DoSomeThing(7, tentacvu, ConsoleColor.Yellow);
          }
        , "T3");
        t3.Start();

        //t3.Wait();
        await t3;
        Console.WriteLine("T3 finished");

        //return t3;
    }

    // Async/await
    static async Task Main(string[] args)
    {
        Task t2 = Task2();
        Task t3 = Task3();

        DoSomeThing(6, "T1", ConsoleColor.Magenta); // Task chính

        //Task.WaitAll(t2, t3);
        await t2;
        await t3;

        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    static async Task Abc()
    {
        /* Task task = new Task(() =>
        {
            // Cac chi thi
        });
        task.Start();
        await task;
        // ...*/

        await File.WriteAllTextAsync("1.txt", "loaniuoi");
        // ...
    }
}