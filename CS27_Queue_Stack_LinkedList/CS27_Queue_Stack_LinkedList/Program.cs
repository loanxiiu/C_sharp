internal class Program
{
    private static void Main(string[] args)
    {
        Queue<string> cachoso = new Queue<string>();
        cachoso.Enqueue("Ho so 1");
        cachoso.Enqueue("Ho so 2");
        cachoso.Enqueue("Ho so 3");
        foreach(var hs in cachoso)
        {
            Console.WriteLine(hs);
        }
        var hoso = cachoso.Dequeue();
        Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");

        hoso = cachoso.Dequeue();
        Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");

        hoso = cachoso.Dequeue();
        Console.WriteLine($"Xu ly ho so: {hoso} - {cachoso.Count}");

    }
}