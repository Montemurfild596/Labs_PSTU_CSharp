using LabClassLibrary;

namespace Lab_12
{
	public class Program
	{
		static void Main(string[] args)
		{
			DeList f = new DeList();
			f.Print();
			DeList first = new DeList();
			first.Print();
			first.Add(new Item());
			first.Print();
            first.Add();
			first.Print();
			DeList second = new DeList(10);
			Console.WriteLine("Печать!");
			second.Print();
            Console.WriteLine("Печать?");
            second.Insert(-1, new Item());
            Console.WriteLine("Печать!");
            second.Print();
            Console.WriteLine("Печать?");
            second.Insert(4, new Item());
            Console.WriteLine("Печать!");
            second.Print();
            Console.WriteLine("Печать?");
            second.Insert(15, new Item());
            Console.WriteLine("Печать!");
            second.Print();
            Console.WriteLine("Печать?");
            second.Insert(second.Count + 1, new Item());
            Console.WriteLine("Печать!");
            second.Print();
            Console.WriteLine("Печать?");
        }
	}
}