// Post dữ liệu nội dụng JSON với StringContent

using System.Net.Http.Headers;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        using var httpClient = new HttpClient();
        var httpMessageRequest = new HttpRequestMessage();

        httpMessageRequest.Method = HttpMethod.Post;
        httpMessageRequest.RequestUri = new Uri("https://postman-echo.com/post");
        httpMessageRequest.Headers.Add("User-Agent", "Mozilla/5.0");

        string data = @"{
            ""key1"": ""giatri1"",
            ""key2"": ""giatri2""
        }";

        Console.WriteLine(data);

        var content = new StringContent(data, Encoding.UTF8, "application/json");
        httpMessageRequest.Content = content;

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