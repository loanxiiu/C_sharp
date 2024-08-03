internal class Program
{
    class Product
    {
        public string Name { set; get; }
        public double Price { set; get; }
        public int Id { set; get; }
        public string Origin { set; get; }

    }
    private static void Main(string[] args)
    {
        SortedList<string, Product> products = new SortedList<string, Product>();
        products["sanpham1"] = new Product() { Name = "Iphone 15 Pro Max", Price = 30000000, Id = 1, Origin = "USA" };
        products["sanpham2"] = new Product() { Name = "Tu lanh SAMSUNG", Price = 10000000, Id = 2, Origin = "Korea" };
        products.Add("sanpham3", new Product() { Name = "May Say quan ao SAMSUNG", Price = 15000000, Id = 3, Origin = "Korea" });

        var p = products["sanpham2"];
        Console.WriteLine(p.Name);

        var keys = products.Keys;
        var values = products.Values;
        
        foreach(var key in keys)
        {
            var product = products[key];
            Console.WriteLine(product.Name);
        }

        foreach (KeyValuePair<string, Product> item in products)
        {
            var key = item.Key;
            var value = item.Value;
            Console.WriteLine($"{key} - {value.Name}");
        }

        products.Remove("sanpham1");
        products.RemoveAt(0);
        products.Clear();
    }
}