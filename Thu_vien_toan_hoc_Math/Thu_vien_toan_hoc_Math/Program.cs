using System;
class Program
{
    static void Main(string[] args)
    {
        // Hang so
        //Console.WriteLine($"Hang so PI {Math.PI}, E: {Math.E}");

        // Max, Min
        double a = 33;
        double b = 4;
        double c = 0.4;
         
        Console.WriteLine($"Max {Math.Max(Math.Max(a, b), c)}");

        // Abs, Sign
        Console.WriteLine($"Gia tri tuyet doi: {Math.Abs(-23)}");

        // Luong giac 
        // Sin, Cos, Tan, Asin, Acos, Atan
        Console.WriteLine($"Sin : {Math.Sin(Math.PI / 4)}");
        //PI ~ 180
        double deg = 60;
        double rad = Math.PI * deg / 180;
        Console.WriteLine($"Sin : {Math.Sin(rad)}");

        /*for(int i=0; i<=90; i++)
        {
            rad = Math.PI * i / 180;
            Console.WriteLine($"Sin {i} (deg): {Math.Sin(rad)}");
        }*/

        // Sqrt(a), Pow(a,b), Log(a), Log10(a)
        Console.WriteLine($"Can : {Math.Sqrt(4)}");
        Console.WriteLine($"Luy thua : {Math.Pow(2, 3)}");
        Console.WriteLine($"Log: {Math.Log(5)}");

        // Lam tron
        // Math.Round(a);    5.6 => 6; 5.4 => 5
        // Math.Ceiling(a1); 5.1, 5.5, 5.7 => 6
        // Math.Floor(b1);   5.1, 5.5, 5.7 => 5
        // Math.Truncate(a); cat phan thap phan
        Console.WriteLine($"Round: {Math.Truncate(5.1)}");
    }
}