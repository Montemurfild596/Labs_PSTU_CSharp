using System;
using MyClassLibrary;

namespace Lab_5
{
	partial class main
	{
		static int MIN = int.MinValue;
		static int MAX = int.MaxValue;

		// функция ввода границ диапазона
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

		/*
		 * 
		 * функции заполнения массивов
		 * 
		 */

		// функция заполнения одномерного массива случайными числами
		static void RandomFillingMas(ref int[] mas)
		{
			int lower, upper;
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
			Random rnd = new Random();
			int masLength;
			masLength = Input.TypePositiveInteger("Введите положительное значение размера массива: ");
			mas = new int[masLength];
			for (int i = 0; i < mas.Length; ++i)
			{
				mas[i] = rnd.Next(lower, upper + 1);
			}
		}

		// функция заполнения двумерного массива случайными числами
		static void RandomFillingMas(ref int[,] mas)
		{
			int lower, upper;
			InputBoundaries(out lower, out upper, "\tВвод границ отрезка случайных чисел");
			Random rnd = new Random();
			int newCountRows, newCountCols;
			newCountRows = Input.TypePositiveInteger("Введите количество строк: ");
			newCountCols = Input.TypePositiveInteger("Введите количество столбцов: ");
			mas = new int[newCountRows, newCountCols];
			for (int i = 0; i < newCountRows; ++i)
			{
				for (int j = 0; j < newCountCols; ++j)
				{
					mas[i, j] = rnd.Next(lower, upper + 1);
				}
			}
		}

		// функция заполнения рваного массива случайными числами
		static void RandomFillingMas(ref int[][] mas)
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

		// функция заполнения одномерного массива значениями пользователя
		static void UserFillingMas(ref int[] mas)
		{
			int masLength;
			masLength = Input.TypePositiveInteger("Введите положительное значение размера массива: ");
			mas = new int[masLength];
			for (int i = 0; i < mas.Length; ++i)
			{
				mas[i] = Input.TypeInteger($"Введите значение {i + 1} элемента: ");
			}
		}

		// функция заполнения двумерного массива значениями пользователя
		static void UserFillingMas(ref int[,] mas)
		{
			int newCountRows, newCountCols;
			newCountRows = Input.TypePositiveInteger("Введите количество строк: ");
			newCountCols = Input.TypePositiveInteger("Введите количество столбцов: ");
			mas = new int[newCountRows, newCountCols];
			for (int i = 0; i < newCountRows; ++i)
			{
				for (int j = 0; j < newCountCols; ++j)
				{
					mas[i, j] = Input.TypeInteger($"Введите значение элемента с индексами [{i + 1}, {j + 1}] : ");
				}
			}
		}

		// функция заполнения рваного массива значениями пользователя
		static void UserFillingMas(ref int[][] mas)
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

		/*
		 * 
		 * функции нахождения минимальных и максимальных элементов
		 * 
		 */

		//нахождение значения максимального элемента одномерного массива
		static void FindMaxValue(int[] mas, out int max)
		{
			max = MIN;
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.Length; ++i)
				{
					max = max < mas[i]
						? mas[i]
						: max;
				}
				Print($"Максимальный элемент массива - {max}\n");
			}
			else
            {
				Print("Массив пустой, поиск максимального элемента невозможен\n");
            }
		}

		// нахождение значения максимального элемента одномерного массива и его индекса
		static void FindIndexMaxValue(int[] mas, out int max, out int index)
		{
			index = 0; max = MIN;
			if (mas.Length != 0) {
				for (int i = 0; i < mas.Length; ++i)
				{
					if (max < mas[i])
                    {
						max = mas[i];
						index = i;
                    }
				}
				Print($"Элемент с номером {index + 1} имеет максимальное значение в массиве, равное {max}\n");
			}
			else
            {
				Print("Поиск максимального элемента невозможен\n");
            }
		}

		//нахождение значения максимального элемента двумерного массива
		static void FindMaxValue(int[,] mas, out int max)
		{
			max = MIN;
			if (mas.Length != 0)
			{
				int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						max = max < mas[i, j]
							? mas[i, j]
							: max;
					}
				}
				Print($"Максимальный элемент массива - {max}\n");
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива\n");
            }
		}

		// нахождение значения максимального элемента двумерного массива и его индексов
		static void FindIndexMaxValue(int [,] mas, out int max, out int row, out int col)
		{
			row = 0; col = 0; max = MIN;
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			if (mas.Length != 0)
			{
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
				Print($"Элемент с номером [{row + 1}:{col + 1}] имеет максимальное значение в массиве, равное {max}\n");
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива\n");
            }
		}

		//нахождение значения максимального элемента рваного массива
		static void FindMaxValue(int[][] mas, out int max)
		{
			max = MIN; 
			int rows = mas.GetUpperBound(0) + 1;
			if (mas.Length != 0)
			{
				for (int i = 0; i < rows; ++i)
				{
					foreach (int temp in mas[i])
					{
						max = max < temp
							? temp
							: max;
					}
				}
				Print($"Максимальный элемент массива - {max}\n");
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива\n");
			}
		}

		// нахождение значения максимального элемента рваного массива и его индексов
		static void FindIndexMaxValue(int[][] mas, out int max, out int row, out int col)
		{
			row = 0; col = 0;
			max = MIN;
			int rows = mas.GetUpperBound(0) + 1;
			if (mas.Length != 0)
			{
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
				Print($"Элемент с номером [{row + 1}:{col + 1}] имеет максимальное значение в массиве, равное {max}\n");
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива\n");
			}
		}

		//нахождение значения минимального элемента одномерного массива
		static void FindMinValue(int[] mas, out int min)
		{
			min = MAX;
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.Length; ++i)
				{
					min = min > mas[i]
						? mas[i]
						: min;
				}
				Print($"Максимальный элемент массива - {min}\n");
			}
			else
            {
				Print($"Невозможно найти минимальный элемент массива\n");
            }
		}

		// нахождение значения минимального элемента одномерного массива и его индекса
		static void FindIndexMinValue(int[] mas, out int min, out int index)
		{
			min = MAX; index = 0;
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.Length; ++i)
				{
					if (min > mas[i])
                    {
						min = mas[i];
						index = i;
                    }
				}
				Print($"Элемент с номером {index + 1} имеет максимальное значение в массиве, равное {min}\n");
			}
			else
            {
				Print($"Невозможно найти минимальный элемент массива\n");
            }
		}

		//нахождение значения минимального элемента двумерного массива
		static void FindMinValue(int[,] mas, out int min)
		{
			min = MAX; 
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			if (mas.Length != 0)
			{
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						min = min > mas[i, j]
							? mas[i, j]
							: min;
					}
				}
				Print($"Максимальный элемент массива - {min}\n");
			}
			else
            {
				Print($"Невозможно найти минимальный элемент массива\n");
			}
		}

		// нахождение значения минимального элемента двумерного массива и его индексов
		static void FindIndexMinValue(int[,] mas, out int min, out int row, out int col)
		{
			row = 0; col = 0; min = MAX;
			int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
			if (mas.Length != 0)
			{
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						if (min > mas[i, j])
						{
							min = mas[i, j];
							row = i;
							col = j;
						}
					}
				}
				Print($"Элемент с номером [{row + 1}:{col + 1}] имеет максимальное значение в массиве, равное {min}\n");
			}
			else
            {
				Print($"Невозможно найти минимальный элемент массива\n");
			}
		}

		//нахождение значения минимального элемента рваного массива
		static void FindMinValue(int[][] mas, out int min)
		{
			min = MAX; 
			int rows = mas.GetUpperBound(0) + 1;
			if (mas.Length != 0)
			{
				for (int i = 0; i < rows; ++i)
				{
					foreach (int temp in mas[i])
					{
						min = min > temp
							? temp
							: min;
					}
				}
				Print($"Максимальный элемент массива - {min}\n");
			}
			else
            {
				Print($"Невозможно найти минимальный элемент массива\n");
			}
		}

		// нахождение значения минимального элемента рваного массива и его индексов
		static void FindIndexMinValue(int[][] mas, out int min, out int row, out int col)
		{
			row = 0; col = 0; min = MAX;
			int rows = mas.GetUpperBound(0) + 1;
			if (mas.Length != 0)
			{
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j <= mas[i].Length; ++j)
					{
						if (min > mas[i][j])
						{
							min = mas[i][j];
							row = i;
							col = j;
						}
					}
				}
				Print($"Элемент с номером [{row + 1}:{col + 1}] имеет максимальное значение в массиве, равное {min}\n");
			}
			else {
				Print($"Невозможно найти минимальный элемент массива\n");
			}
		}

		/*
		 * 
		 * работа с массивами
		 * 
		 */

		// удаление нечётных элементов из одномерного массива
		static void DeleteOddElements(ref int[] mas)
		{
			if (mas.Length != 0)
			{
				int countEven = 0;
				for (int i = 0; i < mas.Length; ++i)
				{
					countEven += mas[i] % 2 == 0
						? 1
						: 0;
				}
				int[] result = new int[countEven];
				for (int i = 0, j = 0; i < mas.Length; ++i)
				{

					if (mas[i] % 2 == 0)
					{
						result[j] = mas[i];
					}
					
				}
				mas = new int[countEven];
				for (int i = 0; i < mas.Length; ++i)
                {
					mas[i] = result[i];
                }
			}
			else
            {
				Print("Массив пустой, удаление нечётных элементов невозможно\n");
            }
		}

		// добавление строки после строки с максимальным элементом
		static void AddRowAfterMax(ref int[,] mas)
		{
			Print("Добавление строки в двумерный массив\n");
			if (mas.Length != 0) {
				int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows, max = MIN;
				int newRows = rows + 1, indexI, indexJ;
				FindIndexMaxValue(mas, out max, out indexI, out indexJ);
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
				mas = new int[newRows, cols];
				for (int i = 0; i < newRows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						mas[i, j] = newMas[i, j];
					}
				}
			}
			else
            {
				Print($"Добавление строки невозможно, так как массив пустой\n");
            }
			
		}
		
		// добавление строки в начало массива
		static int[][] AddRowAfterFirstRow(ref int[][] mas)
        {
			int rows = mas.GetUpperBound(0) + 2, firstElems = Input.TypePositiveInteger("Введите количество элементов первой строки: ");
			int[][] newMas = new int[rows][];
			newMas[0] = new int[firstElems];
			for (int i = 1; i < rows; ++i)
            {
				newMas[i] = new int[mas[i - 1].Length];
            }
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
		static void PrintMas(int [] mas)
		{
			Print("");
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.Length; ++i)
				{
					Console.Write(mas[i] + " ");
				}
				Print("");
			}
			else
            {
				Print("Массив пустой\n");
            }
		}

		// функция вывода двумерного массива в консоль
		static void PrintMas(int [,] mas)
		{
			Print("");
			if (mas.Length != 0)
			{
				int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						Console.Write(mas[i, j] + " ");
					}
					Print("");
				}
				Print("");
			}
			else
            {
				Print("Массив пуст");
            }
		}

		// функция вывода рваного массива в консоль
		static void PrintMas(int [][] mas)
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

		/*
		 * 
		 *  меню
		 * 
		 */

		// меню одномерного массива
		static void oneDemisionMasMenu(ref int[] oneDemisionMas)
        {
			int userChoiseOneDemisionMas, oneDemisionMasMaxValue, oneDemisionMasMinValue;
			do
			{
				Print("1. Создание одномерного массива и его заполнение\n" +
					  "2. Вывод одномерного массива\n" +
					  "3. Удаление нечётных элементов\n" +
					  "4. Поиск максимального элемента\n" +
					  "5. Поиск номера максимального элемента\n" +
					  "6. Поиск минимального элемента\n" +
					  "7. Поиск номера минимального элемента\n" +
					  "0. Назад");
				userChoiseOneDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
				switch (userChoiseOneDemisionMas)
				{
					case 1:
						Print("Создание одномерного массива и его заполнение");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода");
						int userChoiseOneDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseOneDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref oneDemisionMas);
								break;
							case 2:
								UserFillingMas(ref oneDemisionMas);
								break;
							default:
								Print("Ошибка: создание массива невозможно,\nтак как введено неверное значение\n");
								break;
						}
						break;
					case 2:
						Print("Вывод одномерного массива");
						PrintMas(oneDemisionMas);
						break;
					case 3:
						Print("Удаление нечётных элементов");
						DeleteOddElements(ref oneDemisionMas);
						break;
					case 4:
						Print("Поиск максимального элемента");
						FindMaxValue(oneDemisionMas, out oneDemisionMasMaxValue);
						break;
					case 5:
						Print("Поиск индекса максимального элемента");
						int oneDemisionMasIndexMaxValue;
						FindIndexMaxValue(oneDemisionMas, out oneDemisionMasMaxValue, out oneDemisionMasIndexMaxValue);
						break;
					case 6:
						Print("");
						FindMinValue(oneDemisionMas, out oneDemisionMasMinValue);
						break;
					case 7:
						Print("");
						int oneDemisionMasIndexMinValue;
						FindIndexMinValue(oneDemisionMas, out oneDemisionMasMinValue, out oneDemisionMasIndexMinValue);
						break;
					case 0:
						break;
					default:
						Print("Неизвестная функция");
						break;
				}
			} while (userChoiseOneDemisionMas != 0);
		}

		//меню двумерного масссива
		static void twoDemisionMasMenu(ref int[,] twoDemisionMas)
        {
			int userChoiseTwoDemisionMas;
			int twoDemisionMasMaxValue, twoDemisionMasMinValue;
			do
			{
				Print("1. Создание двумерного массива и его заполнение\n" +
					  "2. Вывод двумерного массива\n" +
					  "3. Добавление строки после максимального\n" +
					  "4. Поиск максимального элемента\n" +
					  "5. Поиск максимального элемента\n" +
					  "6. Поиск минимального элемента\n" +
					  "7. Поиск номера минимального элемента\n" +
					  "0. Назад");
				userChoiseTwoDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
				switch (userChoiseTwoDemisionMas)
				{
					case 1:
						Print("Создание двумерного массива и его заполнение");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода");
						int userChoiseTwoDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseTwoDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref twoDemisionMas);
								break;
							case 2:
								UserFillingMas(ref twoDemisionMas);
								break;
							default:
								Print("Ошибка: создание массива невозможно,\nтак как введено неверное значение\n");
								break;
						}
						break;
					case 2:
						Print("Вывод одномерного массива");
						PrintMas(twoDemisionMas);
						break;
					case 3:
						Print("Удаление нечётных элементов");
						AddRowAfterMax(ref twoDemisionMas);
						break;
					case 4:
						Print("Поиск максимального элемента");
						FindMaxValue(twoDemisionMas, out twoDemisionMasMaxValue);
						break;
					case 5:
						Print("Поиск индекса максимального элемента");
						int rowMaxValue, colMaxValue;
						FindIndexMaxValue(twoDemisionMas, out twoDemisionMasMaxValue, out rowMaxValue, out colMaxValue);
						break;
					case 6:
						Print("");
						FindMinValue(twoDemisionMas, out twoDemisionMasMinValue);
						break;
					case 7:
						Print("");
						int rowMinValue, colMinValue;
						FindIndexMinValue(twoDemisionMas, out twoDemisionMasMinValue, out rowMinValue, out colMinValue);
						break;
					case 0:
						break;
					default:
						Print("Неизвестная функция");
						break;
				}
			} while (userChoiseTwoDemisionMas != 0);
		}

		// меню ступенчатого массива
		static void stairsMasMenu(ref int[][] stairsMas)
        {
			int userChoiseStairsDemisionMas, stairsDemisionMasMaxValue, stairsDemisionMasMinValue;
			do
			{
				Print("1. Создание рваного массива и его заполнение\n" +
					  "2. Вывод рваного массива\n" +
					  "3. Добавление строки в начало\n" +
					  "4. Поиск максимального элемента\n" +
					  "5. Поиск максимального элемента\n" +
					  "6. Поиск минимального элемента\n" +
					  "7. Поиск номера минимального элемента\n" +
					  "0. Назад");
				userChoiseStairsDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
				switch (userChoiseStairsDemisionMas)
				{
					case 1:
						Print("Создание двумерного массива и его заполнение");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода");
						int userChoiseStairsDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseStairsDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref stairsMas);
								break;
							case 2:
								UserFillingMas(ref stairsMas);
								break;
							default:
								Print("Ошибка: создание массива невозможно,\nтак как введено неверное значение\n");
								break;
						}
						break;
					case 2:
						Print("Вывод одномерного массива");
						PrintMas(stairsMas);
						break;
					case 3:
						Print("Удаление нечётных элементов");
						AddRowAfterFirstRow(ref stairsMas);
						break;
					case 4:
						Print("Поиск максимального элемента");
						FindMaxValue(stairsMas, out stairsDemisionMasMaxValue);
						break;
					case 5:
						Print("Поиск индекса максимального элемента");
						int rowMaxValue, colMaxValue;
						FindIndexMaxValue(stairsMas, out stairsDemisionMasMaxValue, out rowMaxValue, out colMaxValue);
						break;
					case 6:
						Print("");
						FindMinValue(stairsMas, out stairsDemisionMasMinValue);
						break;
					case 7:
						Print("");
						int rowMinValue, colMinValue;
						FindIndexMinValue(stairsMas, out stairsDemisionMasMinValue, out rowMinValue, out colMinValue);
						break;
					case 0:
						break;
					default:
						Print("Неизвестная функция");
						break;
				}
			} while (userChoiseStairsDemisionMas != 0);
		}

		// главное меню
		static void Menu(int[] oneDemisionMas, int[,] twoDemisionMas, int[][] stairsMas)
        {
			int userChoise;
			do
			{
				Print("1. Работа с одномерными массивами\n" +
					  "2. Работа с двумерными массивами\n" +
					  "3. Работа с рваными массивами\n" +
					  "0. Выход");
				userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
				switch (userChoise)
				{
					case 1:
						oneDemisionMasMenu(ref oneDemisionMas);
						break;
					case 2:
						twoDemisionMasMenu(ref twoDemisionMas);
						break;
					case 3:
						stairsMasMenu(ref stairsMas);
						break;
					case 0:
						break;
					default:
						Print("Неизвестная функция");
						break;
				}
			} while (userChoise != 0);
		}

		// функция вывода сообщения
		static void Print(string message)
        {
			Console.WriteLine(message);
		}

		static void Main(string[] args)
		{
			int[] oneDemisionMas = new int[0];
			int[,] twoDemisionMas = new int[0, 0];
			int[][] stairsMas = new int[0][];
			Menu(oneDemisionMas, twoDemisionMas, stairsMas);
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
