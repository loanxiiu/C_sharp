using System.Net;

class Program
{
    static async Task Main(string[] args)
    {
        // Kiem tra
        if (HttpListener.IsSupported)
        {
            Console.WriteLine("Support HttpListener");
        }
        else
        {
            Console.WriteLine("Not support HttpListener");
            throw new Exception("Not support HttpListener");
        }

        var server = new HttpListener();
        server.Prefixes.Add("http://localhost:8080/");
        server.Start();
        Console.WriteLine("Server HTTP Start");

        do
        {
            var context = await server.GetContextAsync();
            Console.WriteLine("Client connected");

            var response = context.Response;
            var outputStream = response.OutputStream;

            response.Headers.Add("Content-type", "text/html");

            var html = "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Data Submission</title>\r\n</head>\r\n<body>\r\n    <h1>Submit Data</h1>\r\n    <form id=\"dataForm\">\r\n        <label for=\"username\">Username:</label>\r\n        <input type=\"text\" id=\"username\" name=\"username\" required>\r\n        <label for=\"password\">Password:</label>\r\n        <input type=\"password\" id=\"password\" name=\"password\" required>\r\n        <button type=\"submit\">Submit</button>\r\n    </form>\r\n\r\n    <script>\r\n        document.getElementById(\"dataForm\").addEventListener(\"submit\", async function(event) {\r\n            event.preventDefault();\r\n\r\n            const username = document.getElementById(\"username\").value;\r\n            const password = document.getElementById(\"password\").value;\r\n            const data = `Username: ${username}, Password: ${password}`;\r\n\r\n            try {\r\n                const socket = new WebSocket(\"ws://localhost:8080/ws\");\r\n                socket.onopen = function(event) {\r\n                    socket.send(data);\r\n                    alert(\"Data sent to server: \" + data);\r\n                };\r\n\r\n                socket.onmessage = function(event) {\r\n                    alert(\"Response from server: \" + event.data);\r\n                    if(event.data === \"accountTrue\"){\r\n                        loginSuccess();\r\n                    } else {\r\n                        alert(\"Tài khoản hoặc mật khẩu không chính xác\");\r\n                    }\r\n                    socket.close();\r\n                };\r\n            } catch (error) {\r\n                console.error(\"WebSocket error: \", error);\r\n            }\r\n        });\r\n\r\n        function loginSuccess() {\r\n            //window.location.replace(\"//Network_Programming//KiemTra.html\");\r\n        }\r\n    </script>\r\n</body>\r\n</html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(html);
            await outputStream.WriteAsync(buffer, 0, buffer.Length);
            response.Close();

        } while (server.IsListening);
    }
}