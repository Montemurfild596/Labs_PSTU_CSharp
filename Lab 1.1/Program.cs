using MyClassLibrary;
using System;

namespace Lab_1._1
{
	class Program
	{
		static void Main(string[] args)
		{
			int n, m;
			double x;
			n = Input.TypeInteger("Введите n: ");
			m = Input.TypeInteger("Введите m: ");
			x = Input.TypeDouble("Введите x: ");
			Console.WriteLine($"N, M = {n}, {m}");
			Console.WriteLine($"m-++n = { m-++n }");
			Console.WriteLine($"N, M = {n}, {m}");
			Console.WriteLine($"m++>--n = { m++>--n }");
			Console.WriteLine($"N, M = {n}, {m}");
			Console.WriteLine($"m--<++n = { m--<++n }");
			Console.WriteLine("X = " + x);
			Console.WriteLine($"Asin(|X + 1|) = { Math.Asin( Math.Abs( x + 1 ) ) }");
		}
	}
}
