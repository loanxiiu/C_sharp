// Đọc HttpResponseMessage bằng ReadAsByteAsync
using System.Net;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
        var bytes = await DowloadDataBytes(url);
        string filename = "1.png";
        using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        stream.Write(bytes, 0, bytes.Length);
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
    public static async Task<byte[]> DowloadDataBytes(string url)
    {
        using var httpClient = new HttpClient();
        try
        {
            // Thêm headers
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
            HttpResponseMessage httpResponMessage = await httpClient.GetAsync(url);
            ShowHeaders(httpResponMessage.Headers);
            var bytes = await httpResponMessage.Content.ReadAsByteArrayAsync();
            return bytes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
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