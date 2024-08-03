internal class Program
{
    private static void Main(string[] args)
    {
        /* string path = "Abc";
        Directory.CreateDirectory(path);
        if (Directory.Exists(path))
        {
            Console.WriteLine($"{path} - ton tai");
        }
        else
        {
            Console.WriteLine($"{path} - khong ton tai");

        }
        Directory.Delete(path); */

        string path = "obj";
        Directory.CreateDirectory(path);
        var files = Directory.GetFiles(path);
        var directories = Directory.GetDirectories(path);

        foreach(var directory in directories)
        {
            Console.WriteLine(directory);
        }
        Console.WriteLine("----------------");
        foreach(var file in files)
        {
            Console.WriteLine(file);
        }
    }
}