using System;
using MyClassLibrary;

namespace Lab_6
{
    class Program
    {

		/*
		 * 
		 * 1 задача
		 * 
		 */


		static void InputBoundaries(out int a, out int b, string message)
		{
			string buf;
			bool isCorrectLeftBoundary, isCorrectRightBoundary, isUpperMoreThanLower = false, isNotAllRight;
			do
			{
				Console.WriteLine(message);
				Console.Write("Введите нижнюю границу: ");
				buf = Console.ReadLine();
				isCorrectLeftBoundary = Int32.TryParse(buf, out a);
				Console.Write("Введите верхнюю границу: ");
				buf = Console.ReadLine();
				isCorrectRightBoundary = Int32.TryParse(buf, out b);
				if (!isCorrectRightBoundary || !isCorrectLeftBoundary)
				{
					if (!isCorrectRightBoundary && !isCorrectLeftBoundary)
					{
						Console.WriteLine("Ошибка: значения нижней и верхней границ не соответствуют типу integer");
					}
					else if (!isCorrectRightBoundary)
					{
						Console.WriteLine("Ошибка: значение верхней границы не соответствует типу integer");
					}
					else
					{
						Console.WriteLine("Ошибка: значение нижней границы не соответствует типу integer");
					}
				}
				else
				{
					isUpperMoreThanLower = b >= a;
					if (!isUpperMoreThanLower)
					{
						Console.WriteLine("Ошибка: значение нижней границы больше верхней границы");
					}
				}
				isNotAllRight = !isCorrectRightBoundary || !isCorrectLeftBoundary || !isUpperMoreThanLower;
			} while (isNotAllRight);
		}

		static void RandomFillingArray(ref int[][] mas)
		{
			int lower, upper;
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
			Random rnd = new Random();
			int newCountRows, newCountElems;
			newCountRows = Input.TypePositiveInteger("Введите количество строк массива: ");
			mas = new int[newCountRows][];
			for (int i = 0; i < newCountRows; ++i)
			{
				newCountElems = Input.TypePositiveInteger($"Введите количество элементов в {i + 1} строке: ");
				mas[i] = new int[newCountElems];
			}
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = rnd.Next(lower, upper + 1);
				}
			}
		}

		static void UserFillingArray(ref int[][] mas)
		{
			int newCountRows, newCountElems;
			newCountRows = Input.TypePositiveInteger("Введите количество строк массива: ");
			mas = new int[newCountRows][];
			for (int i = 0; i < newCountRows; ++i)
			{
				newCountElems = Input.TypePositiveInteger($"Введите количество элементов в {i + 1} строке: ");
				mas[i] = new int[newCountElems];
			}
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = Input.TypeInteger($"Введите значение элемента с индексами [{i + 1}, {j + 1}] : ");
				}
			}
		}

		static void PrintMas(int[][] mas)
		{
			Print("");
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
				{
					foreach (int temp in mas[i])
					{
						Console.Write(temp + " ");
					}
					Print("");
				}
				Print("");
			}
			else
			{
				Print("Массив пустой\n");
			}
		}

		static void Print(string message)
		{
			Console.WriteLine(message);
		}
		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
