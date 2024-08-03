internal class Program
{
    // DriveInfo
    private static void Main(string[] args)
    {
        // DriveInfo drives = new DriveInfo("/");
        var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
        Console.WriteLine($"Drive Type: {drive.DriveType}");
        Console.WriteLine($"Label: {drive.VolumeLabel}");
        Console.WriteLine($"Fomat: {drive.DriveFormat}");
        Console.WriteLine($"Size: {drive.TotalSize}");
        Console.WriteLine($"Free: {drive.TotalFreeSpace}");
        }
    }
}