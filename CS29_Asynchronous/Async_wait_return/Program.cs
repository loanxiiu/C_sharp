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

    static async Task<string> Task4()
    {
        Task<string> t4 = new Task<string>(
        () =>
        {
            DoSomeThing(5, "T4", ConsoleColor.Cyan);
            return "Return from T4";
        });
        t4.Start();
        var kq = await t4;
        Console.WriteLine("T4 finished");
        return kq;
    }

    static async Task<string> Task5()
    {
        Task<string> t5 = new Task<string>(
        (object ob) =>
        {
            string tentacvu = (string)ob;
            DoSomeThing(8, tentacvu, ConsoleColor.Blue);
            return "Return from T5";
        }
        , "T5");
        t5.Start();
        var kq = await t5;
        Console.WriteLine("T5 finished");
        return kq;
    }

    // Async download web
    static async Task<string> GetWeb(string url)
    {
        HttpClient httpClient = new HttpClient();
        Console.WriteLine("Bat dau tai");
        HttpResponseMessage kq = await httpClient.GetAsync(url);
        Console.WriteLine("Bat dau doc noi dung");
        string content = await kq.Content.ReadAsStringAsync();
        Console.WriteLine("Hoan thanh");
        return content;
    }
    
    // Async/await
    static async Task Main(string[] args)
    {
        /* // Task<string> t4 = new Task<string>(Func<string>); // () => {return string;}
        Task<string> t4 = new Task<string>(
            () =>
            {
                DoSomeThing(5, "T4", ConsoleColor.Cyan);
                return "Return from T4";
            });

        // Task<string> t5 = new Task<string>(Func<object, string>, object); // () => {return string}
        Task<string> t5 = new Task<string>(
            (object ob) =>
            {
                string tentacvu = (string)ob;
                DoSomeThing(8, tentacvu, ConsoleColor.Blue);
                return "Return from T5";
            }
        ,"T5");

        t4.Start();
        t5.Start(); */


        /* Task<string> t4 = Task4();
        Task<string> t5 = Task5();

        DoSomeThing(6, "T1", ConsoleColor.Magenta); // Task chính

        var kq4 = await t4;
        var kq5 = await t5;
        Console.WriteLine(kq4);
        Console.WriteLine(kq5); */

        /* DoSomeThing(6, "T1", ConsoleColor.Magenta); // Task chính
        Task.WaitAll(t4, t5);
        Console.WriteLine(t4.Result);
        Console.WriteLine(t5.Result); */

        var task = GetWeb("https://tuhocict.com");
        DoSomeThing(6, "T1", ConsoleColor.DarkCyan);
        var content = await task;
        Console.WriteLine(content);

        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    static async Task<Object> Abc()
    {
        Task<Object> task = new Task<object>(
            () =>
            {
                // cac tac vu
                return new object();
            }
        );
        task.Start();
        var result = await task;
        return result;
    }
}