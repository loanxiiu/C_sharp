
namespace CS26_List_SortedList
{
    class Product
    {
        public string Name { set; get; }
        public double Price { set; get; }
        public int Id { set; get; }
        public string Origin { set; get; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone 15 Pro Max", Price = 30000000, Id = 1, Origin = "USA"
                },
                new Product()
                {
                    Name = "Tu lanh SAMSUNG", Price = 10000000, Id = 2, Origin ="Korea"
                },
                new Product()
                {
                    Name = "May Say quan ao SAMSUNG", Price = 15000000, Id = 3, Origin = "Korea"
                }
            };
            // USA
            var p = products.Find(
                (p) =>
                {
                    return p.Origin == "USA";
                }
            );
            if (p != null)
            {
                Console.WriteLine($"{p.Name} - {p.Price} - {p.Origin}");
            } 

            products.Sort(
                (p1, p2) =>
                {
                    if (p1.Price == p2.Price) return 0;
                    if (p1.Price < p2.Price) return -1;
                    return 1;
                }
            );
            Console.WriteLine("-------------");
            foreach(var i in products)
            {
                Console.WriteLine($"{i.Name} - {i.Price} - {i.Origin}");
            }
        }
    }
}
