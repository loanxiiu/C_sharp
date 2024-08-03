using System;
using System.Collections.Generic;
using System.Linq;

namespace Anonymous_example
{
    class Program
    {
        // Anonymous - kieu du lieu vo danh
        // Object - thuoc tinh - chi doc
        // new {thuoc tinh = giatri; thuoctinh2 = giatri2 }
        static void Main(string[] args)
        {
            var sanpham = new
            {
                Ten = "IP15",
                Gia = 16000000,
                NamSX = 2023
            };
            Console.WriteLine(sanpham.Ten);
            Console.WriteLine(sanpham.Gia);

            List<Sinhvien> cacsinhvien = new List<Sinhvien>()
            {
                new Sinhvien() { HoTen = "Loan", Namsinh = 2004, Noisinh = "Ha Noi"},
                new Sinhvien() { HoTen = "Tuan", Namsinh = 2002, Noisinh = "Ha Noi"},
                new Sinhvien() { HoTen = "Hang", Namsinh = 2005, Noisinh = "Ha Noi"}
            };

            var ketqua = from sv in cacsinhvien
                         where sv.HoTen.Contains("u")
                         select new
                         {
                             Ten = sv.HoTen,
                             NS = sv.Noisinh
                         };
            foreach (var sinhvien in ketqua)
            {
                Console.WriteLine(sinhvien.Ten + " - " + sinhvien.NS);
            }


            // Dynamic tenbien;
            // khi nap chay moi xac dinh. De truy cap vao cac thuoc tinh cac phuong thuc ma viec truy cap nay khong dược kiem tra o thoi diem bien dich
            dynamic tenbien1; 
            var tenbien2 = 123;

            Student abc = new Student();
            PrintInfo(abc);
        }

        class Student
        {
            public string Name { set; get; }
            public void Hello() => Console.WriteLine("Hello " +Name);
        }

        static void PrintInfo(dynamic obj)
        {
            obj.Name = "Loaniuoi";
            obj.Hello();
        }

        class Sinhvien
        {
            public string HoTen { set; get; }
            public int Namsinh { set; get; }
            public string Noisinh { set; get; }
        }
    }
}