using System.Net;
using System.Text;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new MyHttpServer(new string[] { "http://localhost:8080/" });
            await server.Start();
        }
    }
    public class MyHttpServer
    {
        private HttpListener listener;

        public MyHttpServer(string[] prefixes)
        {
            if (!HttpListener.IsSupported)
            {
                throw new Exception("HttpListener is not support");
            }
            listener = new HttpListener();
            foreach (string prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }
        }

        public async Task Start()
        {
            listener.Start();
            Console.WriteLine("Http Server started");
            do
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Waiting for a connection...");
                var context = await listener.GetContextAsync();
                await ProcessRequest(context);
                Console.WriteLine(DateTime.Now.ToLongTimeString() + " Client connected");
            } while (listener.IsListening);
        }

        public async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

            var outputStream = response.OutputStream;

            switch (request.Url.AbsolutePath)
            {
                case "/":
                    {
                        var html = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Data Submission</title>\r\n</head>\r\n<body>\r\n    <h1>Submit Data</h1>\r\n    <form id=\"dataForm\">\r\n        <label for=\"username\">Username:</label>\r\n        <input type=\"text\" id=\"username\" name=\"username\" required>\r\n        <label for=\"password\">Password:</label>\r\n        <input type=\"password\" id=\"password\" name=\"password\" required>\r\n        <button type=\"submit\">Submit</button>\r\n    </form>\r\n\r\n    <script>\r\n        document.getElementById(\"dataForm\").addEventListener(\"submit\", async function(event) {\r\n            event.preventDefault();\r\n\r\n            const username = document.getElementById(\"username\").value;\r\n            const password = document.getElementById(\"password\").value;\r\n            const data = `Username: ${username}, Password: ${password}`;\r\n\r\n            try {\r\n                const socket = new WebSocket(\"ws://localhost:8080/ws\");\r\n                socket.onopen = function(event) {\r\n                    socket.send(data);\r\n                    alert(\"Data sent to server: \" + data);\r\n                };\r\n\r\n                socket.onmessage = function(event) {\r\n                    alert(\"Response from server: \" + event.data);\r\n                    if(event.data === \"accountTrue\"){\r\n                        loginSuccess();\r\n                    } else {\r\n                        alert(\"Tài khoản hoặc mật khẩu không chính xác\");\r\n                    }\r\n                    socket.close();\r\n                };\r\n            } catch (error) {\r\n                console.error(\"WebSocket error: \", error);\r\n            }\r\n        });\r\n\r\n        function loginSuccess() {\r\n            //window.location.replace(\"//Network_Programming//KiemTra.html\");\r\n        }\r\n    </script>\r\n</body>\r\n</html>";
                        var buffer = Encoding.UTF8.GetBytes(html);
                        response.ContentLength64 = buffer.Length;
                        await outputStream.WriteAsync(buffer, 0, buffer.Length);

                    }
                    break;
            }

            outputStream.Close();
        }
    }
}