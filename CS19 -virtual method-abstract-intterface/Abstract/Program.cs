namespace Abstract
{
    abstract class Product
    {
        protected double Price { get; set; }
        public abstract void ProductInfo();
        public void Test() => ProductInfo();
    }
    class  Iphone: Product
    {
        public Iphone() => Price = 500;
        public override void ProductInfo()
        {
            Console.WriteLine("Iphone");
            Console.WriteLine("Gia san pham " + Price);
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