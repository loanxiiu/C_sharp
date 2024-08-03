internal class Program
{
    private static void Main(string[] args)
    {
        /* string filename = "abc.txt";
        string content = "Loaniuoi";
        File.WriteAllText(filename, content);
        File.AppendAllText(filename, content);

        string content2 = File.ReadAllText(filename);
        Console.WriteLine(content2);*/

        //File.Move("abc.txt", "123.txt");
        File.Copy("123.txt", "456.txt");
        //File.Delete("456.txt");
    }
}