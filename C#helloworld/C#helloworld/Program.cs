using System;
 class Agh
{
    static void Main()
    {
        //System.Console.WriteLine("Loaniu");
        Console.WriteLine(Tong(1, 2));
    }

    /// <summary>
    /// Phương thức trả về tong của 2 số nguyên
    /// </summary>
    /// <param name="a">Số nguyên 1</param>
    /// <param name="b">Số nguyên 2</param>
    /// <returns>Tong a+b </returns>
    static int Tong(int a, int b)
    {
        return (a + b);
    }
}