// Lớp Dns, IPHostEntry
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        /*var hostname = Dns.GetHostName();
        Console.WriteLine(hostname);*/

        var url = "https://stackoverflow.com/";
        var uri = new Uri(url);
        Console.WriteLine(uri.Host);

        var iphostentry = Dns.GetHostEntry(uri.Host);
        Console.WriteLine(iphostentry.HostName);
        iphostentry.AddressList.ToList().ForEach(ip =>
        {
            Console.WriteLine(ip);
        });

    }
}