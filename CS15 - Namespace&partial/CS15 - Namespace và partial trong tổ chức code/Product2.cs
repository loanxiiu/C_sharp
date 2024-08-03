namespace Sanpham
{
    public partial class Product
    {
        public Manufactory manufactory { set; get; }
        public string description { set; get; }

         public class Manufactory
        {
            public string name { set; get; }
            public string addr { set; get; }

        }
        public string Info()
        {
            return $"{manufactory.name} at {manufactory.addr}";
        }
    }
}