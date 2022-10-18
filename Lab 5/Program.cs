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
		static void RandomFillingArray(int [] mas)
        {
			int lower, upper;
			InputRandomBoundaries(out lower, out upper);
			Random rnd = new Random();
			for (int i = 0; i < mas.Length; ++i)
            {
				mas[i] = rnd.Next(lower, upper + 1);
            }
        }
		// функция заполнения двумерного массива случайными числами
		static void RandomFillingArray(int [,] mas)
        {
			int lower, upper;
			InputRandomBoundaries(out lower, out upper);
			Random rnd = new Random();
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
            {
				for (int j = 0; j < cols; ++j)
                {
					mas[i, j] = rnd.Next(lower, upper + 1);
                }
            }
        }
		// функция заполнения рваного массива случайными числами
		static void RandomFillingArray(int[][] mas)
		{

		}
		// функция заполнения одномерного массива значениями пользователя
		static void UserFillingArray(int [] mas)
        {
			for (int i = 0; i < mas.Length; ++i)
            {
				mas[i] = Input.TypeInteger($"Введите значение {i + 1} элемента: ");
            }
        }
		// функция заполнения двумерного массива значениями пользователя
		static void UserFillingArray(int [,] mas)
        {

        }
		// функция заполнения рваного массива значениями пользователя
		static void UserFillingArray(int[][] mas)
		{

		}
		static void PrintArray(int [] mas)
        {
			for (int i = 0; i < mas.Length; ++i)
            {
				Console.Write(mas[i] + " ");
            }
			Console.WriteLine();
        }
		static void PrintArray(int [,] mas)
        {
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			Console.WriteLine(mas.GetUpperBound(0));
			for (int i = 0; i < rows; ++i)
            {
				for (int j = 0; j < cols; ++j)
                {
					Console.Write(mas[i, j] + " ");
                }
				Console.WriteLine();
            }
			Console.WriteLine();
		}
		static void PrintArray(int [][] mas)
        {

        }
		static void Main(string[] args)
		{
			int[] mas1 = new int[4];
			PrintArray(mas1);
			UserFillingArray(mas1);
			PrintArray(mas1);
			int[,] mas2 = new int[4, 5];
			PrintArray(mas2);

		}
	}
}