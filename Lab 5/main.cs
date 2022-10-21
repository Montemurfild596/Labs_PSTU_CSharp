using System;
using MyClassLibrary;

namespace Lab_5
{
	partial class main
	{
		static int MIN = int.MinValue;
		static int MAX = int.MaxValue;

		static void InputBoundaries(out int a, out int b, string message)
		{
			string buf;

			// переменные для проверки границ универсума (верхняя больше нижней, обе положительные и целочисленные)
			bool isCorrectLeftBoundary, isCorrectRightBoundary, isUpperMoreThanLower = false, isNotAllRight;
			do
			{
				Console.WriteLine(message);
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

		/*
		 * 
		 * функции заполнения массивов
		 * 
		 */

		// функция заполнения одномерного массива случайными числами
		static void RandomFillingArray(int [] mas)
		{
			int lower, upper;
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
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
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
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
			int lower, upper;
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
			Random rnd = new Random();
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = rnd.Next(lower, upper + 1);
				}
			}
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
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					mas[i, j] = Input.TypeInteger($"Введите значение элемента с индексами [{i + 1}, {j + 1}] : ");
				}
			}
		}

		// функция заполнения рваного массива значениями пользователя
		static void UserFillingArray(int[][] mas)
		{
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				for (int j = 0; j < mas[i].Length; ++j)
				{
					mas[i][j] = Input.TypeInteger($"Введите значение элемента с индексами [{i + 1}, {j + 1}] : ");
				}
			}
		}

		/*
		 * 
		 * функции нахождения минимальных и максимальных элементов
		 * 
		 */

		//нахождение значения максимального элемента одномерного массива
		static int FindMaxValue(int[] mas)
		{
			int max = MIN;
			for (int i = 0; i < mas.Length; ++i)
			{
				max = max < mas[i]
					? mas[i]
					: max;
			}
			return max;
		}

		// нахождение значения максимального элемента одномерного массива и его индекса
		static void FindIndexMaxValue(int[] mas, out int index)
		{
			int max = MIN;
			index = 0;
			for (int i = 0; i < mas.Length; ++i)
			{
				max = max < mas[i]
					? mas[i]
					: max;
				index = max < mas[i]
					? i
					: index;
			}
		}

		//нахождение значения максимального элемента двумерного массива
		static int FindMaxValue(int[,] mas)
		{
			int max = MIN, rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					max = max < mas[i, j]
						? mas[i, j]
						: max;
				}
			}
			return max;
		}

		// нахождение значения максимального элемента двумерного массива и его индексов
		static void FindIndexMaxValue(int [,] mas, out int row, out int col)
		{
			row = 0; col = 0;
			int max = MIN, rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					if (max < mas[i, j])
					{
						max = mas[i, j];
						row = i;
						col = j;
					}
				}
			}
		}

		//нахождение значения максимального элемента рваного массива
		static int FindMaxValue(int[][] mas)
		{
			int max = MIN, rows = mas.GetUpperBound(0) + 1;
			for (int i = 0; i < rows; ++i)
			{
				foreach (int temp in mas[i])
				{
					max = max < temp
						? temp
						: max;
				}
			}
			return max;
		}

		// нахождение значения максимального элемента рваного массива и его индексов
		static void FindMaxValue(int[][] mas, out int row, out int col)
		{
			row = 0; col = 0;
			int max = MIN, rows = mas.GetUpperBound(0) + 1;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j <= mas[i].Length; ++j)
				{
					if (max < mas[i][j])
					{
						max = mas[i][j];
						row = i;
						col = j;
					}
				}
			}
		}

		//нахождение значения минимального элемента одномерного массива
		static int FindMinValue(int[] mas)
		{
			int max = MAX;
			for (int i = 0; i < mas.Length; ++i)
			{
				max = max > mas[i]
					? mas[i]
					: max;
			}
			return max;
		}

		// нахождение значения минимального элемента одномерного массива и его индекса
		static void FindIndexMinValue(int[] mas, out int index)
		{
			int max = MAX;
			index = 0;
			for (int i = 0; i < mas.Length; ++i)
			{
				max = max > mas[i]
					? mas[i]
					: max;
				index = max > mas[i]
					? i
					: index;
			}
		}

		//нахождение значения минимального элемента двумерного массива
		static int FindMinValue(int[,] mas)
		{
			int max = MIN, rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					max = max > mas[i, j]
						? mas[i, j]
						: max;
				}
			}
			return max;
		}

		// нахождение значения минимального элемента двумерного массива и его индексов
		static void FindIndexMinValue(int[,] mas, out int row, out int col)
		{
			row = 0; col = 0;
			int max = MIN, rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					if (max > mas[i, j])
					{
						max = mas[i, j];
						row = i;
						col = j;
					}
				}
			}
		}

		//нахождение значения минимального элемента рваного массива
		static int FindMinValue(int[][] mas)
		{
			int max = MIN, rows = mas.GetUpperBound(0) + 1;
			for (int i = 0; i < rows; ++i)
			{
				foreach (int temp in mas[i])
				{
					max = max > temp
						? temp
						: max;
				}
			}
			return max;
		}

		// нахождение значения минимального элемента рваного массива и его индексов
		static void FindIndexMinValue(int[][] mas, out int row, out int col)
		{
			row = 0; col = 0;
			int max = MIN, rows = mas.GetUpperBound(0) + 1;
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j <= mas[i].Length; ++j)
				{
					if (max > mas[i][j])
					{
						max = mas[i][j];
						row = i;
						col = j;
					}
				}
			}
		}

		/*
		 * 
		 * работа с массивами
		 * 
		 */

		// удаление нечётных элементов из одномерного массива
		static int[] DeleteOddElements(int[] mas)
		{
			int countEven = 0;
			for (int i = 0; i < mas.Length; ++i)
			{
				countEven += mas[i] % 2 == 0
					? 1
					: 0;
			}
			int[] result = new int[countEven];
			for (int i = 0, j = 0; i < mas.Length; ++i, ++j)
			{
				if (mas[i] % 2 == 0)
				{
					result[j] = mas[i];
				} 
				else
				{
					++i;
				}
			}

			return result;
		}
		static int[,] AddRowAfterMax(int [,] mas)
		{
			Console.WriteLine("Добавление строки в двумерный массив");
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			int newRows = rows + 1, indexI, indexJ;
			FindIndexMaxValue(mas, out indexI, out indexJ);
			int[,] newMas = new int[newRows, cols];
			int isIndexMaxRow = 0;
			for (int i = 0; i < newRows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					if (i == indexI + 1)
					{
						newMas[i, j] = Input.TypeInteger($"Введите элемент {i + 1} строки {j + 1} столбца: ");
					}
					else
					{
						newMas[i, j] = mas[i - isIndexMaxRow, j];
					}
				}
				isIndexMaxRow = i >= indexI
					? 1
					: 0;
			}
			return newMas;
		}

		static int[][] AddRowAfterFirstRow(int [][] mas)
        {
			int rows = mas.GetUpperBound(0) + 2, firstElems = Input.TypePositiveInteger("Введите количество элементов первой строки: ");
			int[][] newMas = new int[rows][];
			newMas[0] = new int[firstElems];
			for (int i = 1; i < rows; ++i)
            {
				newMas[i] = new int[mas[i - 1].Length];
            }
			PrintArray(newMas);
			for (int i = 0; i < newMas[0].Length; ++i)
            {
				newMas[0][i] = Input.TypeInteger($"Введите {i + 1} элемент новой строки: ");
            }
			for (int i = 1; i < rows; ++i)
            {
				for (int j = 0; j < newMas[i].Length; ++j)
                {
					newMas[i][j] = mas[i - 1][j];
                }
            }
			return newMas;

        }

		/*
		 * 
		 * функции вывода массивов
		 * 
		 */

		// функция вывода одномерного массива в консоль
		static void PrintArray(int [] mas)
		{
			Console.WriteLine("----------Вывод одномерного массива----------");
			for (int i = 0; i < mas.Length; ++i)
			{
				Console.Write(mas[i] + " ");
			}
			Console.WriteLine();
		}

		// функция вывода двумерного массива в консоль
		static void PrintArray(int [,] mas)
		{
			Console.WriteLine("----------Вывод двумерного массива----------");
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
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

		// функция вывода рваного массива в консоль
		static void PrintArray(int [][] mas)
		{
			Console.WriteLine("----------Вывод рваного массива----------");
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
			{
				foreach (int temp in mas[i])
				{
					Console.Write(temp + " ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}

		/*
		 * 
		 *  меню
		 * 
		 */

		//

		static void Main(string[] args)
		{
			int[] masOneDemisionRand = new int[4];
			int[] masOneDemisionUser = new int[7];
			int[,] masTwoDemisionRand = new int[2, 3];
			int[,] masTwoDemisionUser = new int[3, 2];
			int[][] masStairsRand = new int[3][];
			masStairsRand[0] = new int[5];
			masStairsRand[1] = new int[3];
			masStairsRand[2] = new int[2];
			int[][] masStairsUser = new int[3][];
			masStairsUser[0] = new int[2];
			masStairsUser[1] = new int[1];
			masStairsUser[2] = new int[3];
			//RandomFillingArray(masOneDemisionRand);
			//RandomFillingArray(masOneDemisionUser);
			//UserFillingArray(masOneDemisionUser);
			//RandomFillingArray(masTwoDemisionRand);
			//RandomFillingArray(masTwoDemisionUser);
			//UserFillingArray(masTwoDemisionUser);
			RandomFillingArray(masStairsRand);
			UserFillingArray(masStairsUser);
			//PrintArray(masOneDemisionRand);
			//PrintArray(masOneDemisionUser);
			//PrintArray(masTwoDemisionRand);
			//PrintArray(masTwoDemisionUser);
			PrintArray(masStairsRand);
			PrintArray(masStairsUser);
			//masOneDemisionRand = DeleteOddElements(masOneDemisionRand);
			//masOneDemisionUser = DeleteOddElements(masOneDemisionUser);
			//masTwoDemisionRand = AddRowAfterMax(masTwoDemisionRand);
			//masTwoDemisionUser = AddRowAfterMax(masTwoDemisionUser);
			//PrintArray(masOneDemisionRand);
			//PrintArray(masOneDemisionUser);
			//PrintArray(masTwoDemisionRand);
			//PrintArray(masTwoDemisionUser);
			masStairsRand = AddRowAfterFirstRow(masStairsRand);
			masStairsUser = AddRowAfterFirstRow(masStairsUser);
			PrintArray(masStairsRand);
			PrintArray(masStairsUser);
		}
	}
}



	//-1234
	//1234
	//0
	//0
	//0
	//0
	//12
	//1234
	//1
	//2
	//3
	//1
	//2
