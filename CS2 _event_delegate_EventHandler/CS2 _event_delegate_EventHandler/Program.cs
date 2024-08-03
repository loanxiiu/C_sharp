 namespace CS_Event
{
    /* publisher -> class - phat su kien
    subsrciber -> class - nhan su kien */
    // publisher
    public delegate void SuKienNhapSo(int x);
    class UserInput
    {
        public event SuKienNhapSo sukiennhapso;
        public void Input()
        {
            do
            {
                string s = Console.ReadLine();
                int i = Int32.Parse(s);
                sukiennhapso?.Invoke(i);
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
        public void Can(int i)
        {
            Console.WriteLine($"Can bac 2 cua so {i} = {Math.Sqrt(i)}");
        }
    }

    class TinhBinhPhuong
    {
        public void Sub(UserInput input)
        {
            input.sukiennhapso += BinhPhuong;
        }
        public void BinhPhuong(int i)
        {
            Console.WriteLine($"Binh phuong cua so {i} = {i*i}");
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            //Publisher
            UserInput userInput = new UserInput();

            userInput.sukiennhapso += x =>
            {
                Console.WriteLine("Ban vua nhap so: " + x);
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
