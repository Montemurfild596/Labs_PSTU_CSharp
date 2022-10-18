using System;
using MyClassLibrary;

namespace Lab_5
{
	class Program
	{
		static void InputRandomBoundaries(out int a, out int b)
        {
			string buf;

			// переменные для проверки границ универсума (верхняя больше нижней, обе положительные и целочисленные)
			bool isCorrectLeftBoundary, isCorrectRightBoundary, isUpperMoreThanLower = false, isNotAllRight = false;
			do
			{
				Console.Write("Введите нижнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectLeftBoundary = Int32.TryParse(buf, out a);
				Console.Write("Введите верхнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectRightBoundary = Int32.TryParse(buf, out b);
				if (!isCorrectRightBoundary || !isCorrectLeftBoundary)
				{
					if (!isCorrectRightBoundary && !isCorrectLeftBoundary)
					{
						Console.WriteLine("Ошибка: значения нижней и верхней границ универсума не соответствует типу integer");
					}
					else if (!isCorrectRightBoundary)
					{
						Console.WriteLine("Ошибка: значение верхней границы универсума не соответствует типу integer");
					}
					else
					{
						Console.WriteLine("Ошибка: значение нижней границы универсума не соответствует типу integer");
					}
				}
				else
				{
					isUpperMoreThanLower = b >= a;
					if (!isUpperMoreThanLower)
					{
						Console.WriteLine("Ошибка: значение нижней границы универсума больше верхней границы");
					}
				}
				isNotAllRight = !isCorrectRightBoundary || !isCorrectLeftBoundary || !isUpperMoreThanLower;
			} while (isNotAllRight);
		}
		// функция заполнения одномерного массива случайными числами
		static void RandomFillingArray(int []arr)
        {
			int lower, upper;

			for (int i = 0; i < arr.Length; ++i)
            {

            }
        }
		// функция заполнения двумерного массива случайными числами
		static void RandomFillingArray(int [,]arr)
        {

        }
		// функция заполнения рваного массива случайными числами
		static void RandomFillingArray(int[][] arr)
		{

		}
		// функция заполнения одномерного массива значениями пользователя
		static void userFillingArray(int []arr)
        {

        }
		// функция заполнения двумерного массива значениями пользователя
		static void userFillingArray(int [,]arr)
        {

        }
		// функция заполнения рваного массива значениями пользователя
		static void userFillingArray(int[][] arr)
		{

		}
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
