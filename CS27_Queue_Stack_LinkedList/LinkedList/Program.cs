internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList<string> cacbaihoc = new LinkedList<string>();
        var bh1 = cacbaihoc.AddFirst("Bai hoc 1");
        var bh3 = cacbaihoc.AddLast("Bai hoc 3");
        LinkedListNode<string> bh2 = cacbaihoc.AddAfter(bh1, "Bai hoc 2");
        cacbaihoc.AddLast("Bai hoc 4");
        cacbaihoc.AddLast("Bai hoc 5");
        foreach(var data in cacbaihoc)
        {
            Console.WriteLine(data);
        }

        var node = bh2;
        Console.WriteLine(node.Value);

        node = node.Next;
        Console.WriteLine(node.Value);

        node = cacbaihoc.Last;
        while (node != null)
        {
            Console.WriteLine(node.Value);
            node = node.Previous;
            Console.WriteLine(node.Value);
        }
    }
}