using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace delegatingHandler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://postman-echo.com/post";
            var cookies = new CookieContainer();

            var bottomHandler = new MyHttpClientHandler(cookies);
            var changeUriHandler = new ChangeUri(bottomHandler);
            var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler);

            using var httpClient = new HttpClient(denyAccessFacebook);

            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2"));

            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);
            var response = await httpClient.SendAsync(httpRequestMessage);

            cookies.GetCookies(new Uri(url)).ToList().ForEach(c =>
            {
                Console.WriteLine($"{c.Name} : {c.Value}");
            });
            var html = await response.Content.ReadAsStringAsync();
            Console.WriteLine(html);

        }
        
    }

    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {
            CookieContainer = cookie_container; // Thay thế CookieContainer mặc định
            AllowAutoRedirect = false; // Không cho tự động Redirect
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true; // Cho phép sử dụng Cookie
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Bắt đầu kết nối " + request.RequestUri.ToString());
            // Thực hiện truy vấn đến Server
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine("Hoàn thành tài dữ liệu");
            return response;
        }
    }

    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in ChangeUri - {host}");
            if (host.Contains("google.com"))
            {
                // Đổi địa chỉ truy cập từ google sang github
                request.RequestUri = new Uri("https://github.com/");
            }
            return base.SendAsync(request, cancellationToken);
        }
    }

    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var host = request.RequestUri.Host.ToLower();
            Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }


}