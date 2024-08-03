// Upload dữ liệu phức tạp (upload file) với MultipartFormDataContent, StreamContent

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

        var content = new MultipartFormDataContent();

        // Upload file 1.txt
        Stream fileStream = File.OpenRead("1.txt");
        var fileUpload = new StreamContent(fileStream);
        content.Add(new StringContent("value1"), "key1");

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