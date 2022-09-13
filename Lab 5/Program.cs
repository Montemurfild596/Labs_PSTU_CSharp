using System;
using MyClassLibrary;

namespace Lab_5
{
	class Program
	{
		static void Main(string[] args)
		{
			Random rnd = new Random();
			int strings, columns;
			strings = Input.TypeInteger("Введите количество строк двумерного массива: ");
			columns = Input.TypeInteger("Введите количество столбцов двумерного массива: ");
			int[,] randomArray = new int[strings, columns];
			for (uint i = 0; i < strings; ++i)
            {
				for (uint j = 0; j < columns; ++j)
                {
					randomArray[i, j] = rnd.Next(0, 10);
                }
            }
			for (uint i = 0; i < strings; ++i)
            {
				for (uint j = 0; j < columns; ++j)
                {
					Console.Write(randomArray[i, j] + " ");
                }
				Console.WriteLine();
            }
		}
	}
}
