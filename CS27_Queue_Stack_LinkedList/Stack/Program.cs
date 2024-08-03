internal class Program
{
    // Vào sau ra trước
    private static void Main(string[] args)
    {
        Stack<string> hanghoa = new Stack<string>();
        hanghoa.Push("mat hang 1");
        hanghoa.Push("mat hang 2");
        hanghoa.Push("mat hang 3");

        var mathang = hanghoa.Pop();
        Console.WriteLine($"Boc do: {mathang}");

        mathang = hanghoa.Pop();
        Console.WriteLine($"Boc do: {mathang}");

        mathang = hanghoa.Pop();
        Console.WriteLine($"Boc do: {mathang}");


    }
}