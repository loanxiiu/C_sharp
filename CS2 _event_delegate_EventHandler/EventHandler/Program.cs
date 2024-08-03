namespace CS_Event
{
    /* publisher -> class - phat su kien
    subsrciber -> class - nhan su kien */
    // publisher
    public delegate void SuKienNhapSo(int x);

    class Dulieunhap : EventArgs
    {
        public int data { set; get; }
        public Dulieunhap(int x) => data = x;
    }
    class UserInput
    {
        // ~ delegate void KIEU( object? sender, EventArgs args)
        public event EventHandler sukiennhapso;
        public void Input()
        {
            do
            {
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                sukiennhapso?.Invoke(this, new Dulieunhap(i));
            }
            while (true);
        }
    }

    class TinhCan
    {
        public void Sub(UserInput input)
        {
            input.sukiennhapso += Can;
        }
        public void Can(object sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Can bac 2 cua so {i} = {Math.Sqrt(i)}");
        }
    }

    class TinhBinhPhuong
    {
        public void Sub(UserInput input)
        {
            input.sukiennhapso += BinhPhuong;
        }
        public void BinhPhuong(object sender, EventArgs e)
        {
            Dulieunhap dulieunhap = (Dulieunhap)e;
            int i = dulieunhap.data;
            Console.WriteLine($"Binh phuong cua so {i} = {i * i}");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine();
                Console.WriteLine("Thoat ung dung");
            };

            //Publisher
            UserInput userInput = new UserInput();

            userInput.sukiennhapso += (sender, e) =>
            {
                Dulieunhap dulieunhap = (Dulieunhap)e;
                Console.WriteLine("Ban vua nhap so: " + dulieunhap.data);
            };

            //Subscriber
            TinhCan tinhCan = new TinhCan();
            tinhCan.Sub(userInput);

            TinhBinhPhuong tinhBinhPhuong = new TinhBinhPhuong();
            tinhBinhPhuong.Sub(userInput);

            userInput.Input();

        }
    }
}