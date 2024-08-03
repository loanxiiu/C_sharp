using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "data.txt";
        using var stream = new FileStream(path, FileMode.OpenOrCreate);

        // luu du lieu
        byte[] buffer = { 1, 2, 255 };
        int offset = 0;
        int count = 3;
        stream.Write(buffer, offset, count);

        // Doc du lieu
        int sobytedocduoc = stream.Read(buffer, offset, count);

        // int, double -> bytes
        int abc = 1;
        var bytes_abc = BitConverter.GetBytes(abc);

        // bytes -> int, double...
        BitConverter.ToInt32(bytes_abc, 0);

        string s = "Abc";
        var byte_s = Encoding.UTF8.GetBytes(s);

        Encoding.UTF8.GetString(byte_s, 0, 10);
    }
}