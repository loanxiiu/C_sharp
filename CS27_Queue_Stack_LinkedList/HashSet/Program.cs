internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<int> set1 = new HashSet<int>() { 1, 2, 5, 9, 7 };
        HashSet<int> set2 = new HashSet<int>() { 3, 5, 6, 10 };
        // set1.UnionWith(set2);
        set1.IntersectWith(set2);
        foreach (var item in set1)
        {
            Console.WriteLine(item);
        }
    }
}