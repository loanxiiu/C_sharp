internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Path.DirectorySeparatorChar);
        var path = Path.Combine("Dir1", "Dir2", "Tenfile.txt");
        Console.WriteLine(path);

        var path2 = "Dir1/Dir2/Tenfile.txt";
        path2 = Path.ChangeExtension(path, "md");
        Console.WriteLine(path2);
        Console.WriteLine(Path.GetDirectoryName(path));

        var path3 = Path.GetRandomFileName();
        Console.WriteLine(path3);

        var path4 = Path.GetTempFileName();
        Console.WriteLine(path4);
    }
}