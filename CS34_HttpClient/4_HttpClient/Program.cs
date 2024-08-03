// Sử dụng HttpClient gửi truy vấn get tới HttpServer
class Program
{
    /* static void Main(string[] args)
    {
        var url = "https://www.google.com/search?q=xuanthulab";
        var task = GetWebContent(url);
        task.Wait();
        var html = task.Result;
        Console.WriteLine(html);
    } */

    static async Task Main(string[] args)
    {
        var url = "https://www.gooogle.com/search?q=xuanthulab";
        var html = await GetWebContent(url);
        Console.WriteLine(html);
    }

    public static async Task<string> GetWebContent(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            HttpResponseMessage httpResponMessage = await httpClient.GetAsync(url);
            string html = await httpResponMessage.Content.ReadAsStringAsync();
            return html;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return "Error";
        }
    }
}