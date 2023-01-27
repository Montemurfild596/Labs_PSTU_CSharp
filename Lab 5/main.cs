using System;
using MyClassLibrary;

namespace Lab_5
{
	partial class main
	{
		static int MIN = int.MinValue;
		static int MAX = int.MaxValue;

		/// <summary>
		/// функция ввода границ диапазона
		/// </summary>
		/// <param name="a">Левая граница</param>
		/// <param name="b">Правая граница</param>
		/// <param name="message">Сообщение</param>
		static void InputBoundaries(out int a, out int b, string message)
		{
			string buf;
			bool isCorrectLeftBoundary, isCorrectRightBoundary, isUpperMoreThanLower = false, isNotAllRight;
			do
			{
				Print(message);
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

		#region Функции заполнения массивов

		#region Функции заполнения массива случайными числами

		/// <summary>
		/// Функция заполнения одномерного массива случайными числами
		/// </summary>
		/// <param name="mas">Одномерный массив</param>
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

		/// <summary>
		/// Функция заполнения двумерного массива случайными числами
		/// </summary>
		/// <param name="mas">Двумерный массив</param>
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

		/// <summary>
		/// Функция заполнения рваного массива случайными числами
		/// </summary>
		/// <param name="mas">Рваный массив</param>
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

		#endregion

		#region Функции заполнения массива пользовательским вводом

		/// <summary>
		/// Функция заполнения одномерного массива значениями пользователя
		/// </summary>
		/// <param name="mas"></param>
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

		/// <summary>
		/// Функция заполнения двумерного массива значениями пользователя
		/// </summary>
		/// <param name="mas"></param>
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

		/// <summary>
		/// Функция заполнения рваного массива значениями пользователя
		/// </summary>
		/// <param name="mas"></param>
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

		#endregion

		#endregion

		#region Функции нахождения минимальных и максимальных элементов

		#region Функции нахождения максимального элемента

		/// <summary>
		/// Нахождение значения максимального элемента одномерного массива
		/// </summary>
		/// <param name="mas">Массив</param>
		/// <param name="max">Максимальное значение</param>
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

		/// <summary>
		/// Нахождение значения максимального элемента одномерного массива и его индекса
		/// </summary>
		/// <param name="mas">Массив</param>
		/// <param name="max">Максимальное значение</param>
		/// <param name="index">Индекс максимального элемента</param>
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

		/// <summary>
		/// Нахождение значения максимального элемента двумерного массива
		/// </summary>
		/// <param name="mas">Массив</param>
		/// <param name="max">Максимальное значение</param>
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

		/// <summary>
		///  Нахождение значения максимального элемента двумерного массива и его индексов
		/// </summary>
		/// <param name="mas">Массив</param>
		/// <param name="max">Максимальное значение</param>
		/// <param name="row">Строка с максимальным значением</param>
		/// <param name="col">Столбец с максимальным значением</param>

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

		/// <summary>
		/// нНахождение значения максимального элемента рваного массива
		/// </summary>
		/// <param name="mas">Массив</param>
		/// <param name="max">Максимальное значение</param>
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

        #endregion

        #region Функции нахождения минимального элемента
        /// <summary>
        ///  Нахождение значения максимального элемента рваного массива и его индексов
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="row">Строка с максимальным значением</param>
        /// <param name="col">Столбец с максимальным значением</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента одномерного массива
		/// </summary>
		/// <param name="mas">Рваный массив</param>
		/// <param name="min">Минимальное значение</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента одномерного массива и его индекса
		/// </summary>
		/// <param name="mas">Одномерный массив</param>
		/// <param name="min">Минимальное значение</param>
		/// <param name="index">Индекс минимального элемента</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента двумерного массива
		/// </summary>
		/// <param name="mas">Двумерный массив</param>
		/// <param name="min">Минимальное значение</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента двумерного массива и его индексов
		/// </summary>
		/// <param name="mas">Двумерный массив</param>
		/// <param name="min">Минимальное значение</param>
		/// <param name="row">Строка с минимальным элементом</param>
		/// <param name="col">Столбец с минимальным элементом</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента рваного массива
		/// </summary>
		/// <param name="mas">Рваный массив</param>
		/// <param name="min">Минимальное значение</param>
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

		/// <summary>
		/// Нахождение значения минимального элемента рваного массива и его индексов
		/// </summary>
		/// <param name="mas">Рваный массив</param>
		/// <param name="min">Минимальное значение</param>
		/// <param name="row">Строка с минимальным элементом</param>
		/// <param name="col">Столбец с минимальным элементом</param>
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
        #endregion

        #endregion

        #region Функции работы с массивами

        /// <summary>
        /// Функция удаления нечётных элементов из одномерного массива
        /// </summary>
        /// <param name="mas">Одномерный массив</param>
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
						++j;
					}
					
				}
				PrintMas(result);
				mas = new int[countEven];
				for (int i = 0; i < mas.Length; ++i)
                {
					mas[i] = result[i];
                }
				PrintMas(mas);
			}
			else
            {
				Print("Массив пустой, удаление нечётных элементов невозможно\n");
            }
		}

		/// <summary>
		/// Добавление строки после строки с максимальным элементом
		/// </summary>
		/// <param name="mas">Двумерный массив</param>
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

		/// <summary>
		/// Добавление строки в начало массива
		/// </summary>
		/// <param name="mas">Рваный массив</param>
		static void AddRowAfterFirstRow(ref int[][] mas)
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

			mas = newMas;

        }

		#endregion

		#region Функции вывода массивов

		/// <summary>
		/// Функция вывода одномерного массива в консоль
		/// </summary>
		/// <param name="mas">Одномерный массив</param>
		static void PrintMas(int [] mas)
		{
			Print("");
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.Length; ++i)
				{
					Console.Write(mas[i] + " ");
				}
				Print("\n");
			}
			else
            {
				Print("Массив пустой\n");
            }
		}

		/// <summary>
		/// Функция вывода двумерного массива в консоль
		/// </summary>
		/// <param name="mas">Двумерный массив</param>
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
				Print("Массив пустой\n");
            }
			
		}

		/// <summary>
		/// Функция вывода рваного массива в консоль
		/// </summary>
		/// <param name="mas"></param>
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

        #endregion

        #region Функции меню

		/// <summary>
		/// Меню одномерного массива
		/// </summary>
		/// <param name="oneDemisionMas">Одномерный массив</param>
        static void oneDemisionMasMenu(ref int[] oneDemisionMas)
        {
			int userChoiseOneDemisionMas, oneDemisionMasMaxValue, oneDemisionMasMinValue;
			do
			{
				Print("\n1. Создание одномерного массива и его заполнение\n" +
					  "2. Вывод одномерного массива\n" +
					  "3. Удаление нечётных элементов\n" +
					  "4. Поиск максимального элемента\n" +
					  "5. Поиск номера максимального элемента\n" +
					  "6. Поиск минимального элемента\n" +
					  "7. Поиск номера минимального элемента\n" +
					  "0. Назад");
				userChoiseOneDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
				Print("");
				switch (userChoiseOneDemisionMas)
				{
					case 1:
						Print("\n-----Создание одномерного массива и его заполнение-----\n");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода\n");
						int userChoiseOneDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseOneDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref oneDemisionMas);
								Print("-----Создание и заполнение одномерного массива завершено-----\n");
								break;
							case 2:
								UserFillingMas(ref oneDemisionMas);
								Print("-----Создание и заполнение одномерного массива завершено-----\n");
								break;
							default:
								Print("-----\nВведено неверное значение. Создание и заполнение одномерного массива не было завершено-----\n");
								break;
						}
						break;
					case 2:
						Print("\n----------Печать одномерного массива----------\n");
						PrintMas(oneDemisionMas);
						Print("----------Печать одномерного массива завершена----------\n");
						break;
					case 3:
						Print("\n---------Удаление нечётных элементов----------\n");
						DeleteOddElements(ref oneDemisionMas);
						Print("---------Удаление нечётных элементов завершено----------\n");
						break;
					case 4:
						Print("\n----------Поиск максимального элемента----------\n");
						FindMaxValue(oneDemisionMas, out oneDemisionMasMaxValue);
						Print("----------Поиск максимального элемента завершён----------\n");
						break;
					case 5:
						Print("\n----------Поиск номера максимального элемента----------\n");
						int oneDemisionMasIndexMaxValue;
						FindIndexMaxValue(oneDemisionMas, out oneDemisionMasMaxValue, out oneDemisionMasIndexMaxValue);
						Print("----------Поиск номера максимального элемента завершён----------\n");
						break;
					case 6:
						Print("\n----------Поиск минимального элемента----------\n");
						FindMinValue(oneDemisionMas, out oneDemisionMasMinValue);
						Print("---------Поиск минимального элемента завершён----------\n");
						break;
					case 7:
						Print("\n----------Поиск номера минимального элемента----------\n");
						int oneDemisionMasIndexMinValue;
						FindIndexMinValue(oneDemisionMas, out oneDemisionMasMinValue, out oneDemisionMasIndexMinValue);
						Print("----------Поиск номера минимального элемента завершён----------\n");
						break;
					case 0:
						break;
					default:
						Print("\nНеизвестная функция\n");
						break;
				}
			} while (userChoiseOneDemisionMas != 0);
		}

		/// <summary>
		/// Меню двумерного массива
		/// </summary>
		/// <param name="twoDemisionMas">Двумерный массив</param>
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
				Print("");
				userChoiseTwoDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
				switch (userChoiseTwoDemisionMas)
				{
					case 1:
						Print("\n-----Создание двумерного массива и его заполнение-----\n");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода");
						int userChoiseTwoDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseTwoDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref twoDemisionMas);
								Print("-----Создание и заполнение двумерного массива завершено-----\n");
								break;
							case 2:
								UserFillingMas(ref twoDemisionMas);
								Print("-----Создание и заполнение двумерного массива завершено-----\n");
								break;
							default:
								Print("-----\nВведено неверное значение. Создание и заполнение двумерного массива не было завершено-----\n");
								break;
						}
						break;
					case 2:
						Print("\n----------Печать двумерного массива----------\n");
						PrintMas(twoDemisionMas);
						Print("----------Печать двумерного массива завершена----------\n");
						break;
					case 3:
						Print("\n-----Добавление строки после максимального элемента-----\n");
						AddRowAfterMax(ref twoDemisionMas);
						Print("-----Добавление строки после максимального элемента завершено-----\n");
						break;
					case 4:
						Print("\n-----Поиск максимального элемента-----\n");
						FindMaxValue(twoDemisionMas, out twoDemisionMasMaxValue);
						Print("-----Поиск максимального элемента завершено-----\n");
						break;
					case 5:
						Print("\n-----Поиск номера максимального элемента-----\n");
						int rowMaxValue, colMaxValue;
						FindIndexMaxValue(twoDemisionMas, out twoDemisionMasMaxValue, out rowMaxValue, out colMaxValue);
						Print("-----Поиск номера максимального элемента завершено-----\n");
						break;
					case 6:
						Print("\n-----Поиск минимального элемента-----\n");
						FindMinValue(twoDemisionMas, out twoDemisionMasMinValue);
						Print("-----Поиск минимального элемента завершено-----\n");
						break;
					case 7:
						Print("\n-----Поиск номера минимального элемента-----\n");
						int rowMinValue, colMinValue;
						FindIndexMinValue(twoDemisionMas, out twoDemisionMasMinValue, out rowMinValue, out colMinValue);
						Print("-----Поиск номера минимального элемента завершено-----\n");
						break;
					case 0:
						break;
					default:
						Print("\nНеизвестная функция\n");
						break;
				}
			} while (userChoiseTwoDemisionMas != 0);
		}

		/// <summary>
		/// Меню ступенчатого массива
		/// </summary>
		/// <param name="stairsMas">Рваный массив</param>
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
				Print("");
				switch (userChoiseStairsDemisionMas)
				{
					case 1:
						Print("\n-----Создание рваного массива и его заполнение-----\n");
						Print("1. С помощью датчика случайных чисел\n" +
							  "2. С помощью ручного ввода");
						int userChoiseStairsDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
						switch (userChoiseStairsDemisionFilling)
						{
							case 1:
								RandomFillingMas(ref stairsMas);
								Print("-----Создание и заполнение рваного массива завершено-----\n");
								break;
							case 2:
								UserFillingMas(ref stairsMas);
								Print("-----Создание и заполнение рваного массива завершено-----\n");
								break;
							default:
								Print("-----\nВведено неверное значение. Создание и заполнение рваного массива не было завершено-----\n");
								break;
						}
						break;
					case 2:
						Print("\n----------Печать рваного массива----------\n");
						PrintMas(stairsMas);
						Print("----------Печать рваного массива завершена----------\n");
						break;
					case 3:
						Print("\n-----Добавление строки после максимального элемента-----\n");
						AddRowAfterFirstRow(ref stairsMas);
						Print("-----Добавление строки после максимального элемента завершено-----\n");
						break;
					case 4:
						Print("\n-----Поиск максимального элемента-----\n");
						FindMaxValue(stairsMas, out stairsDemisionMasMaxValue);
						Print("-----Поиск максимального элемента завершено-----\n");
						break;
					case 5:
						Print("\n-----Поиск номера максимального элемента-----\n");
						int rowMaxValue, colMaxValue;
						FindIndexMaxValue(stairsMas, out stairsDemisionMasMaxValue, out rowMaxValue, out colMaxValue);
						Print("-----Поиск номера максимального элемента завершено-----\n");
						break;
					case 6:
						Print("\n-----Поиск минимального элемента-----\n");
						FindMinValue(stairsMas, out stairsDemisionMasMinValue);
						Print("-----Поиск минимального элемента завершено-----\n");
						break;
					case 7:
						Print("\n-----Поиск номера минимального элемента-----\n");
						int rowMinValue, colMinValue;
						FindIndexMinValue(stairsMas, out stairsDemisionMasMinValue, out rowMinValue, out colMinValue);
						Print("-----Поиск номера минимального элемента завершено-----\n");
						break;
					case 0:
						break;
					default:
						Print("\nНеизвестная функция\n");
						break;
				}
			} while (userChoiseStairsDemisionMas != 0);
		}

		/// <summary>
		/// Главное меню
		/// </summary>
		/// <param name="oneDemisionMas">Одномерный массив</param>
		/// <param name="twoDemisionMas">Двумерный массив</param>
		/// <param name="stairsMas">Рваный массив</param>
		static void Menu(int[] oneDemisionMas, int[,] twoDemisionMas, int[][] stairsMas)
        {
			int userChoise;
			do
			{
				Print("1. Работа с одномерными массивами\n" +
					  "2. Работа с двумерными массивами\n" +
					  "3. Работа с рваными массивами\n" +
					  "0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
				Print("");
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

        #endregion

        /// <summary>
        /// Функция вывода сообщения
        /// </summary>
        /// <param name="message">Сообщение</param>
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