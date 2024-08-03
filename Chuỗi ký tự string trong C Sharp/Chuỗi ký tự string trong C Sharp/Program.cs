using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string loichao;
        string ten = "\"Loaniuoi\"";
        loichao = "Xin \n chao \t";
        string thongbao = loichao + "cau" + ten;
        thongbao += "!";
        Console.WriteLine(thongbao);

        string thongbao2 = @"Xin chao           2024
                           ""Hoc lap trinh C#""
                           ";
        Console.WriteLine(thongbao2);

        int tien = 2;
        string thongbao3 = 
            $"Loan co {tien} ty VND";
        Console.WriteLine(thongbao3);

        string name = "Loaniuoi";
        int year = 2004;
        string gioitinh = "Nu";
        string thongbao4 =
            $@"
                Hoten: {name,10} 
                Nam sinh: {year,10}
                Gioi Tinh: {gioitinh,10}
            ";
        //$"c {sg,3} f" sau c la 3 ky tu " "
        Console.WriteLine(thongbao4);

        string thongbao5 = "*******loaniuoi          ";
        thongbao5 = thongbao5.Trim( ); // Cắt ký tự ở đầu và ở cuối
        thongbao5 = thongbao5.TrimStart('*');
        thongbao5 = thongbao5.Replace("iuoi", "xinh iu");
        thongbao5 = thongbao5.Insert(0, "chao");
        thongbao5 = thongbao5.Substring(6, 8);
        thongbao5 = thongbao5.Remove(2,1);
        string[] cacchuoicon = thongbao5.Split(' '); 
        foreach(var s in cacchuoicon)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine(thongbao5.ToUpper());
        int dodai = thongbao5.Length;
        Console.WriteLine(dodai);
        //char i = thongbao5[4];
        //Console.WriteLine(i);
        for(int i = 0; i<dodai; i++)
        {
            char c = thongbao5[i];
            Console.WriteLine($"Chi so {i} la ky tu: {c,3}");
        }

        foreach(var kytu in thongbao5)
        {
            Console.WriteLine(kytu);
        }

        string[] cacchuoi =
        {
            "Loan",
            "xinh",
            "iu"
        };
        string thongbao6 = string.Join(' ', cacchuoi);
        Console.WriteLine(thongbao6);

        // Đối tượng xây dựng nên các chuỗi
        StringBuilder thongbao7 = new StringBuilder();
        thongbao7.Append("Xin");
        thongbao7.Append(" chao Loaniuoi");
        thongbao7.Replace("Xin chao", "Chao mung");
        string kq = thongbao7.ToString();
        Console.WriteLine(kq);
    }
}