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
		static void RandomFillingArray(int [] mas)
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
		static void RandomFillingArray(int [,] mas)
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
		static void RandomFillingArray(int[][] mas)
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
		static void UserFillingArray(int [] mas)
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
		static void UserFillingArray(int [,] mas)
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
		static void UserFillingArray(int[][] mas)
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
				Print($"Максимальный элемент массива - {max}");
			}
			else
            {
				Print("Массив пустой, поиск максимального элемента невозможен");
            }
		}

		// нахождение значения максимального элемента одномерного массива и его индекса
		static void FindIndexMaxValue(int[] mas, out int max, out int index)
		{
			index = 0; max = MIN;
			if (mas.Length != 0) {
				for (int i = 0; i < mas.Length; ++i)
				{
					max = max < mas[i]
						? mas[i]
						: max;
					index = max < mas[i]
						? i
						: index;
				}
				Print($"Элемент с индексом {index} имеет максимальное значение в массиве, равное {max}");
			}
			else
            {
				Print("Поиск максимального элемента невозможен ");
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
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива");
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
			}
			else
            {
				Print("Невозможно найти максимальный элемент массива");
            }
		}

		//нахождение значения максимального элемента рваного массива
		static void FindMaxValue(int[][] mas)
		{
			int max = MIN, rows = mas.GetUpperBound(0) + 1;
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
			}
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
		static void DeleteOddElements(int[] mas)
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
				mas = new int[countEven];
				for (int i = 0; i < mas.Length; ++i)
                {
					mas[i] = result[i];
                }
			}
			else
            {
				Print("Массив пустой, удаление нечётных элементов невозможно");
            }
		}

		// добавление строки после строки с максимальным элементом
		static void AddRowAfterMax(int[,] mas)
		{
			Console.WriteLine("Добавление строки в двумерный массив");
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
				Print($"Добавление строки невозможно, так как массив пустой");
            }
			
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
			if (mas.Length != 0)
			{
				Console.WriteLine("----------Вывод одномерного массива----------");
				for (int i = 0; i < mas.Length; ++i)
				{
					Print(mas[i] + " ");
				}
				Console.WriteLine();
			}
			else
            {
				Print("Массив пустой");
            }
		}

		// функция вывода двумерного массива в консоль
		static void PrintMas(int [,] mas)
		{
			//Console.WriteLine("----------Вывод двумерного массива----------");
			if (mas.Length != 0)
			{
				int rows = mas.GetUpperBound(0) + 1, cols = mas.Length / rows;
				for (int i = 0; i < rows; ++i)
				{
					for (int j = 0; j < cols; ++j)
					{
						Print(mas[i, j] + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			}
			else
            {
				Print("Массив пуст");
            }
		}

		// функция вывода рваного массива в консоль
		static void PrintMas(int [][] mas)
		{
			//Console.WriteLine("----------Вывод рваного массива----------");
			if (mas.Length != 0)
			{
				for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
				{
					foreach (int temp in mas[i])
					{
						Print(temp + " ");
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			} 
			else
            {
				Print("Массив пустой");
            }
		}

		/*
		 * 
		 *  меню
		 * 
		 */

		// функция вывода сообщения
		static void Print(string message)
        {
			Console.WriteLine(message);
		}

		static void Main(string[] args)
		{
			int userChoise;
			int[] oneDemisionMas = new int[0];
			int[,] twoDemisionMas = new int[0, 0];
			int[][] stairsMas = new int[0][];
			UserFillingArray(stairsMas);
			PrintMas(stairsMas);
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
						int userChoiseOneDemisionMas;
						int oneDemisionMasMaxValue;
						do
                        {
                            Print("1. Создание одномерного массива и его заполнение\n" +
                                  "2. Вывод одномерного массива\n" +
                                  "3. Удаление нечётных элементов\n" +
                                  "4. Поиск максимального элемента\n" +
                                  "5. Поиск максимального элемента\n" +
                                  "0. Назад");
                            userChoiseOneDemisionMas = Input.TypeInteger("Выберите одну из предложенных функций: ");
							switch (userChoiseOneDemisionMas)
                            {
                                case 1:
                                    Print("Создание одномерного массива и его заполнение");
									Print("1. С помощью датчика случайных чисел\n" +
										  "2. С помощью ручного ввода");
									int userChoiseOneDemisionFilling = Input.TypeInteger("Выберите, каким образом звполнить массив:");
									switch(userChoiseOneDemisionFilling)
                                    {
										case 1:
											RandomFillingArray(oneDemisionMas);
											break;
										case 2:
											UserFillingArray(oneDemisionMas);
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
									DeleteOddElements(oneDemisionMas);
                                    break;
                                case 4:
									Print("Поиск максимального элемента");
									FindMaxValue(oneDemisionMas, out oneDemisionMasMaxValue);
									break;
                                case 5:
									Print("Поиск индекса максимального элемента");
									int index;
									FindIndexMaxValue(oneDemisionMas, out oneDemisionMasMaxValue, out index);
									break;
                                case 0:
                                    break;
                                default:
									Print("Неизвестная функция");
                                    break;
                            }
                        } while (userChoiseOneDemisionMas != 0) ;
                        break;
                    case 2:
						int userChoiseTwoDemisionMas;
						int twoDemisionMasMaxValue;
						do
						{
							Print("1. Создание двумерного массива и его заполнение\n" +
								  "2. Вывод двумерного массива\n" +
								  "3. Удаление нечётных элементов\n" +
								  "4. Поиск максимального элемента\n" +
								  "5. Поиск максимального элемента\n" +
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
											RandomFillingArray(twoDemisionMas);
											break;
										case 2:
											UserFillingArray(twoDemisionMas);
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
									AddRowAfterMax(twoDemisionMas);
									break;
								case 4:
									Print("Поиск максимального элемента");
									FindMaxValue(twoDemisionMas, out twoDemisionMasMaxValue);
									break;
								case 5:
									Print("Поиск индекса максимального элемента");
									int row, col;
									FindIndexMaxValue(twoDemisionMas, out twoDemisionMasMaxValue, out row, out col);
									break;
								case 0:
									break;
								default:
									Print("Неизвестная функция");
									break;
							}
						} while (userChoiseTwoDemisionMas != 0);
						break;
					case 3:

                    case 0:
                        break;
                    default:
                        Print("Неизвестная функция");
                        break;
                }
            } while (userChoise != 0);
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
