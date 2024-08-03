namespace ListExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<int> ds1 = new List<int>();
            ds1.Add(1);
            ds1.Add(2);
            ds1.AddRange(new int[] { 3, 4, 6 });
            //Console.WriteLine(ds1.Count);
            //Console.WriteLine(ds1[ds1.Count - 1]);
            ds1.Insert(0, 10);
            ds1.RemoveAt(2);
            foreach(var n in ds1)
            {
                Console.WriteLine(n);
            }
            var rs = ds1.FindAll(
                (e) =>
                {
                    return e % 3 == 0;
                }
            );
            foreach(var n in rs)
            {
                Console.WriteLine(n);
            }

            List<string> ds2 = new List<string>() {"Loaniuoi"};
        }
    }

}