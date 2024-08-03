internal class Program
{
    private static void Main(string[] args)
    {
        // Khởi tạo với 2 phần tử
        Dictionary<string, int> sodem = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2
        };
        //Thêm hoặc cập nhật
        sodem["three"] = 3;
        sodem.Add("four", 4);

        var keys = sodem.Keys;
        foreach(var k in keys)
        {
            var value = sodem[k];
            Console.WriteLine($"{k} = {value}");
        }

    }
}