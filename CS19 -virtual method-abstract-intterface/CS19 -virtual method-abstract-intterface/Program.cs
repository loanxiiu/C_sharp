// CS19 - Phương thức ảo(virtual method), lớp trừu tượng (abstract) và giao diện intterface

namespace CS10
{
    // vitual method
    abstract class Product
    {
        protected double Price { set; get; }
        public virtual void ProductInfo()
        {
            Console.WriteLine($"Gia san pham: {Price}");
        }
        public void Test() => ProductInfo();
    }

    class Iphone : Product
    {
        // Phuong thuc khoi tao
        public Iphone() => Price = 500;

        // override - nap chong phuong thuc
        public override void ProductInfo()
        {
            Console.WriteLine("Dien thoai cua Loaniuoi");
            base.ProductInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Iphone i = new Iphone();
            i.Test();
        }
    }
}




