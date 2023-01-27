using System;
using System.IO;
using MyClassLibrary;

namespace Lab_6
{
    class Program
    {
		static string path = "/Projects/CSharp/CSharp/lab 6/text.txt";

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

		static void RandomFillingMas(ref double[][] mas)
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
					mas[i][j] = Math.Round(rnd.NextDouble() * (upper - lower) + lower, 5);
				}
			}
		}

		static void UserFillingMas(ref double[][] mas)
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

		static void SortMas(ref double[][] mas)
        {
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
            {
				Array.Sort(mas[i]);
            }
        }

		static void SortMasLength(ref double[][] mas)
        {
			int[] masLength = new int[mas.GetUpperBound(0) + 1];
			for (int i = 0; i < mas.GetUpperBound(0) + 1; ++i)
            {
				masLength[i] = mas[i].Length;
            }
			for (int i = 0; i < masLength.Length; ++i)
            {
				int minElem = masLength[i];
				for (int j = i + 1; j < masLength.Length; ++j)
                {
					if (minElem > masLength[j])
                    {
						double[] firstMas = new double[masLength[i]], secondMas = new double[masLength[j]];
						Array.Copy(mas[i], 0, firstMas, 0, mas[i].Length);
						Array.Copy(mas[j], 0, secondMas, 0, mas[j].Length);
						mas[i] = new double[secondMas.Length];
						for (int k = 0; k < mas[i].Length; ++k)
                        {
							mas[i][k] = secondMas[k];
                        }
						mas[j] = new double[firstMas.Length];
						for (int k = 0; k < mas[j].Length; ++k)
						{
							mas[j][k] = firstMas[k];
						}
						minElem = masLength[j];
						masLength[j] = masLength[i];
						masLength[i] = minElem;
					}
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

		/*
		 * 
		 * 2 задача
		 * 
		 */

		//
		static void UserFillingString(out string text)
        {
			bool isNotAllRght = false;
			Print("Пользовательский ввод строки");
			do
			{
				if (isNotAllRght)
				{
					Print("Ошибка: неправильно введена строка. Введите заново");
				}
				text = Console.ReadLine();
				isNotAllRght = !isCorrectString(text);
			} while (isNotAllRght);
        }

		//
		static void RandomFillingString(out string text, int countSentence)
        {
			text = "";
			StreamReader temp = new StreamReader(path);
			Random rnd = new Random();
			int indexSentence = rnd.Next(1, countSentence);
			Print($"{indexSentence}");
			for (int i = 0; i < indexSentence; ++i)
            {
				text = temp.ReadLine();
            }
			temp.Close();
        }

		static bool IsLetter(char temp)
		{
			int numberChar = temp - '0' + 48;
			bool isEn = (numberChar > 64 && numberChar < 91) || (numberChar > 96 && numberChar < 123);
			bool isRus = (numberChar > 1039 && numberChar < 1072 || numberChar > 1071 && numberChar < 1104);
			return (isEn || isRus);
		}

		//
		static bool isEndSentence(char temp)
		{
			bool isPoint = temp == '.', isExclamationPoint = temp == '!', isAnswerPoint = temp == '?';
			return (isPoint || isExclamationPoint || isAnswerPoint);
		}


		static bool isPunctuationMark(char temp)
		{
			bool isSpace = temp == ' ', isColon = temp == ':', isComma = temp == ',', isSemicolon = temp == ';';
			return (isSpace || isColon || isComma || isSemicolon);
		}

		static bool isCorrectString(string temp)
		{
			bool isAllRight,
				 isEndingRight = isEndSentence(temp[temp.Length - 1]),
				 isStartingRight = IsLetter(temp[0]),
				 isCorrectSymbol = true,
				 isHaveTwiceMarks = false;
			for (int i = 0; i < temp.Length && isCorrectSymbol; ++i)
			{
				if (!IsLetter(temp[i]) && !isEndSentence(temp[i]) && !isPunctuationMark(temp[i]))
				{
					isCorrectSymbol = false;
				}
			}
			for (int i = 0; i < temp.Length - 1 && !isHaveTwiceMarks; ++i)
			{
				if ((isEndSentence(temp[i]) && isEndSentence(temp[i + 1])) || (isPunctuationMark(temp[i]) && isEndSentence(temp[i + 1])))
				{
					isHaveTwiceMarks = true;
				}
			}
			//Print($"{isEndingRight} {isStartingRight} {isCorrectSymbol} {!isHaveTwiceMarks}");
			isAllRight = isEndingRight && isStartingRight && isCorrectSymbol && !isHaveTwiceMarks;

			return isAllRight;
		}

		static void ReverseWords(ref string text)
        {
			int startWordIndex = 0, endWordIndex = 0;
			char[] textChar = new char[text.Length];
			for (int i = 0; i < textChar.Length; ++i)
            {
				textChar[i] = text[i];
            }
			for (int i = 0; i < textChar.Length; ++i)
            {
				if (i != 0 && IsLetter(textChar[i]) && !IsLetter(textChar[i - 1])) {
					startWordIndex = i;
                }
				if (IsLetter(textChar[i]))
                {
					//Print($"--- {i} ---");
					endWordIndex = i;
                }
				if ((i != textChar.Length - 1 && (IsLetter(textChar[i]) && !IsLetter(textChar[i + 1]))) || (i == textChar.Length - 2 && IsLetter(textChar[i]) && IsLetter(textChar[i + 1])))
                {
					//Print($"{startWordIndex}, {endWordIndex}");
					endWordIndex = i;
					for (int j = 0; j <= (endWordIndex - startWordIndex) / 2; ++j)
                    {
						(textChar[startWordIndex + j], textChar[endWordIndex - j]) = (textChar[endWordIndex - j], textChar[startWordIndex + j]);
						//Console.WriteLine(textChar);
						//Print(textChar);
                    }
                }

            }
			text = new string(textChar);
        }

		static void SortingWords(ref string text)
        {

        }

		// 
		static void PrintString(string message)
        {
			Print(message);
        }

		

		//
		static void Print(string message)
		{
			Console.WriteLine(message);
		}

		static void Main(string[] args)
        {
			string a;
			UserFillingString(out a);
			Print(a);
			PrintString(a);
			ReverseWords(ref a);
			PrintString(a);
			string b;
			RandomFillingString(out b, 6);
			PrintString(b);
			ReverseWords(ref b);
			PrintString(b);
			double[][] stairsMas = new double[0][];
			RandomFillingMas(ref stairsMas);
			PrintMas(stairsMas);
			SortMas(ref stairsMas);
			PrintMas(stairsMas);
			SortMasLength(ref stairsMas);
			PrintMas(stairsMas);
        }
    }
}
