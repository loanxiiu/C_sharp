// Post dữ liệu Form HTML lên Server HTTP với FormUrlEncodedContent

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

        // httpMessageRequest.Content => Form HTML, File...
        // POST => FORM HTML
        /*
         * key1 => value1 =>                [Input]
         * key2 => [value2-1, value2-2]     [Multi Select]
         */

        var parameters = new List<KeyValuePair<string, string>>();
        parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
        parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
        parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

        var content = new FormUrlEncodedContent(parameters);
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