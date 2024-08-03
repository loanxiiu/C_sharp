// Đọc HttpResponseMessage bằng ReadAsStreamAsync
using System.Net;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
        await DownloadStream(url, "2.png");
    }


    public static async Task DownloadStream(string url, string filename)
    {
        HttpClient httpClient = new HttpClient();
        try
        {
            var httpResponsseMessage = await httpClient.GetAsync(url);
            using var stream = await httpResponsseMessage.Content.ReadAsStreamAsync();

            using var streamwrite = File.OpenWrite(filename);

            int SIZEBUFFER = 500;
            var buffer = new byte[SIZEBUFFER];

            bool endread = false;
            do
            {
                int numBytes = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
                if (numBytes == 0)
                {
                    endread = true;
                }
                else
                {
                    await streamwrite.WriteAsync(buffer, 0, numBytes);
                }
            } while (!endread);
        }
        catch (Exception e)
        {

        }
    }
}