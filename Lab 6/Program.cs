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


		static void InputDoubleBoundaries(out double a, out double b, string message)
		{
			string buf;
			bool isCorrectLeftBoundary, isCorrectRightBoundary, isUpperMoreThanLower = false, isNotAllRight;
			do
			{
				Console.WriteLine(message);
				Console.Write("Введите нижнюю границу: ");
				buf = Console.ReadLine();
				isCorrectLeftBoundary = Double.TryParse(buf, out a);
				Console.Write("Введите верхнюю границу: ");
				buf = Console.ReadLine();
				isCorrectRightBoundary = Double.TryParse(buf, out b);
				if (!isCorrectRightBoundary || !isCorrectLeftBoundary)
				{
					if (!isCorrectRightBoundary && !isCorrectLeftBoundary)
					{
						Console.WriteLine("Ошибка: значения нижней и верхней границ не соответствуют типу double");
					}
					else if (!isCorrectRightBoundary)
					{
						Console.WriteLine("Ошибка: значение верхней границы не соответствует типу double");
					}
					else
					{
						Console.WriteLine("Ошибка: значение нижней границы не соответствует типу double");
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

		static void RandomFillingArray(ref double[][] mas)
		{
			double lower, upper;
			InputDoubleBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
			Random rnd = new Random();
			int newCountRows, newCountElems;
			newCountRows = Input.TypePositiveInteger("Введите количество строк массива: ");
			mas = new double[newCountRows][];
			for (int i = 0; i < newCountRows; ++i)
			{
				newCountElems = Input.TypePositiveInteger($"Введите количество элементов в {i + 1} строке: ");
				mas[i] = new double[newCountElems];
			}
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = rnd.NextDouble() * (upper - lower) + lower;
				}
			}
		}

		static void UserFillingArray(ref double[][] mas)
		{
			int newCountRows, newCountElems;
			newCountRows = Input.TypePositiveInteger("Введите количество строк массива: ");
			mas = new double[newCountRows][];
			for (int i = 0; i < newCountRows; ++i)
			{
				newCountElems = Input.TypePositiveInteger($"Введите количество элементов в {i + 1} строке: ");
				mas[i] = new double[newCountElems];
			}
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = Input.TypeDouble($"Введите значение элемента с индексами [{i + 1}, {j + 1}] : ");
				}
			}
		}

		static void PrintMas(double[][] mas)
		{
			Print("");
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
				{
					foreach (double temp in mas[i])
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
