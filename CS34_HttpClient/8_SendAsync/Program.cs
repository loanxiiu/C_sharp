// Sử dụng SendAsync của HttpClient gửi các HttpRequest (HttpRequestMessage)
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        using var httpClient = new HttpClient();
        var httpMessageRequest = new HttpRequestMessage();

        httpMessageRequest.Method = HttpMethod.Get;
        httpMessageRequest.RequestUri = new Uri("https://www.google.com.vn");
        httpMessageRequest.Headers.Add("User-Agent", "Mozilla/5.0");

        var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);

        ShowHeaders(httpResponseMessage.Headers);

        var html = await httpResponseMessage.Content.ReadAsStringAsync();
        Console.WriteLine(html);
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