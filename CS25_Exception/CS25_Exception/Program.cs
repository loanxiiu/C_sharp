namespace CS_Exeption
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int a = 5;
            int b = 0;

            // Exception
            try
            {
                var c = a / b;  // phat sinh doi tuong lop Exception, ke thua Exception
                Console.WriteLine(c);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("Phep chia loi");
            }
            Console.WriteLine("Ket thuc");
        }
    }

}