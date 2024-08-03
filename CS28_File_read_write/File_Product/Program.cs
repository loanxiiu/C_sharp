using System.Text;

    internal class Program
    {
        class Product
        {
            public int Id { set; get; }
            public double Price { set; get; }
            public string Name { set; get; }
            public void Save(Stream stream)
            {
                // int -> 4 byte
                var bytes_id = BitConverter.GetBytes(Id);
                stream.Write(bytes_id, 0, 4);

                // double -> 8 byte
                var bytes_price = BitConverter.GetBytes(Price);
                stream.Write(bytes_price, 0, 8);

                // chuoi.Length
                var bytes_name = Encoding.UTF8.GetBytes(Name);
                var bytes_length = BitConverter.GetBytes(bytes_name.Length);
                stream.Write(bytes_length, 0, 4);
                stream.Write(bytes_name, 0, bytes_name.Length);
            }
            public void Restore(Stream stream)
            {
                // int -> 4 byte
                // khởi tạo mảng bytes_id 4 phần tử làm vùng đệm đọc stream
                var bytes_id = new byte[4]; 
                // truy cập vào stream thực hiện phương thức Read đọc vào vùng đệm bytes_id, offset = 0; đọc 4 bytes
                stream.Read(bytes_id, 0, 4);
                // Sau khi có 4 bytes là số nguyên, thực hiện method BitConverter.ToInt32 với mảng bytes_id tính từ chỉ số index = 0; giá trị Id phục hồi từ mảng bytes
                Id = BitConverter.ToInt32(bytes_id, 0);

                var bytes_price = new byte[8];
                stream.Read(bytes_price, 0, 8);
                Price = BitConverter.ToDouble(bytes_price, 0);


                var bytes_length = new byte[4];
                stream.Read(bytes_length, 0, 4);
                int length = BitConverter.ToInt32(bytes_length, 0);

                var bytes_name = new byte[length];
                stream.Read(bytes_name, 0, length);
                Name = Encoding.UTF8.GetString(bytes_name, 0, length);

            }
        }
         static void Main(string[] args)
        {
            string path = "data.txt";
            using var stream = new FileStream(path: path, FileMode.OpenOrCreate);
        /* Product product = new Product()
        {
            Id = 10,
            Price = 15000,
            Name = "Sanpham Abc"
        };
        product.Save(stream); */
        Product product = new Product();


            product.Restore(stream);
            Console.WriteLine($"{product.Id} - {product.Price} - {product.Name}");
            stream.Close();
        }
    }
