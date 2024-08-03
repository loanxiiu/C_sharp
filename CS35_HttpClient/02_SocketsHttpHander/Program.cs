﻿using System.Net;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://postman-echo.com/post";

        using var handler = new SocketsHttpHandler();
        handler.AllowAutoRedirect = true;
        handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

        using var httpClient = new HttpClient();
        using var httpRequestMessage = new HttpRequestMessage();

        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri(url);
        httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

        var parameters = new List<KeyValuePair<string, string>>();
        parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
        parameters.Add(new KeyValuePair<string, string>("key2", "value2"));

        httpRequestMessage.Content = new FormUrlEncodedContent(parameters);
        var response = await httpClient.SendAsync(httpRequestMessage);
        var html = await response.Content.ReadAsStringAsync();
        Console.WriteLine(html);
    }
}