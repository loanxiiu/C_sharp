using System;

namespace CS10
{
    // Interface
    interface IHinhHoc
    {
        public double TinhChuVi();
        public double TinhDienTich();
    }

    class HinhChuNhat : IHinhHoc // , Giaodien2, Giaodien3, ...
    {
        public double a { set; get; }
        public double b { set; get; }

        public HinhChuNhat(double _a, double _b)
        {
            a = _a;
            b = _b;
        }

        public double TinhChuVi()
        {
            return 2 * (a + b);

        }

        public double TinhDienTich()
        {
            return a * b;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // HinhChuNhat h = new HinhChuNhat(4, 5);
            IHinhHoc h = new HinhChuNhat(4, 5);
            Console.WriteLine($"Dien tich: {h.TinhDienTich()}, Chu vi: {h.TinhChuVi()}");
        }
    }
}