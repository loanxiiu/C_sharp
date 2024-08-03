// Địa chỉ Url và lớp Uri
class Program
{
    static void Main(string[] args)
    {
        string url = "https://stackoverflow.com/";
        var uri = new Uri(url);

        var uritype = typeof(Uri);
        uritype.GetProperties().ToList().ForEach(property =>
        {
            Console.WriteLine($"{property.Name, 15} {property.GetValue(uri)}");
        });
        Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
    }
}