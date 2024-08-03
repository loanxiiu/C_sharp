// Đọc các header của httpResponse, Thiết lập header cho HttpRequest
using System.Net;
using System.Net.Http.Headers;

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
        var url = "https://www.google.com/search?q=xuanthulab";
        var html = await GetWebContent(url);
        Console.WriteLine(html);
    }

    public static async Task<string> GetWebContent(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            // Thêm headers
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage httpResponMessage = await httpClient.GetAsync(url);
            ShowHeaders(httpResponMessage.Headers);
            string html = await httpResponMessage.Content.ReadAsStringAsync();
            return html;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return "Error";
        }
    }


    static void ShowHeaders(HttpResponseHeaders headers)
    {
        Console.WriteLine("Cac header");
        foreach (var header in headers)
        {
            Console.WriteLine($"{header.Key} : {header.Value}");
        }
    }
}