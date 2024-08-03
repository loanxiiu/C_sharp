using System;

namespace CS_017
{
    class Vector
    {
        double x;
        double y;
        public Vector(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public void Info()
        {
            Console.WriteLine($"x = {x}, y = {y}");
        }
        // Quá tải toán tử
        // Vector <- Vector + Vector
        public static Vector operator + (Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y);
        }

        // Indexer
        public double this[int i]
        {
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new Exception("Chi so sai");
                        break;
                }
            }

            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new Exception("Chi so sai");
                        break;
                }
            }
        }
    }
    class Student
    {
        public readonly string name = "Loanxinhiu"; // Chỉ đọc
        public Student(string _name)
        {
            this.name = _name;
        }
    }
    class CountNumber
    {
        public static int number = 0;
        public static void Info()
        {
            Console.WriteLine("So lan truy cap: " + number);
        }
        public void Count()
        {
            CountNumber.number++;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*CountNumber.Info();
            Console.WriteLine(CountNumber.number);

            CountNumber c1 = new CountNumber();
            CountNumber c2 = new CountNumber();
            c1.Count();
            c1.Count();
            c2.Count();
            CountNumber.Info();

            Student s = new Student();
            // s.name = "Loaniuoi";
            Console.WriteLine(s.name);*/

            /*Student s = new Student("Loan");
            Console.WriteLine(s.name);8?

            /*Vector v1 = new Vector(2, 3);
            Vector v2 = new Vector(1, 1);
            v1.Info();
            v2.Info();
            
            // Quá tải toán tử
            var v3 = v1 + v2;
            v3.Info();*/

            //Indexer
            Vector v = new Vector(2, 3);
            /* v[0] ~ x
            v[1] ~ y

            v["toadox"] ~ x
            v["toadoy"] ~ y */

            v[0] = 5;
            v[1] = 6;
            v.Info();
            Console.WriteLine(v[3]);
        }
    }

}