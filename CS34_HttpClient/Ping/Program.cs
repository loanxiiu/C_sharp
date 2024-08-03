// Sử dụng ping kiểm tra phản hồi của máy remote

using System.Net.NetworkInformation;

class Program
{
    static void Main(string[] args)
    {
        var ping = new Ping();
        var pingReply = ping.Send("stackoverflow.com");
        Console.WriteLine(pingReply.Status);
        if (pingReply.Status == IPStatus.Success)
        {
            Console.WriteLine(pingReply.RoundtripTime);
            Console.WriteLine(pingReply.Address);
        }
    }
}