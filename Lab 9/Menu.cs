using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace Lab_9
{
    class Menu
    {
		Random rnd = new Random();
        public void MenuFirstPart()
        {
			Console.WriteLine("----- 1 часть -----\n");
			Console.WriteLine("Объект класса Point без параметров: ");
			Point pointWithoutParams = new Point();
			pointWithoutParams.Show();
			pointWithoutParams.ShowLength();
			
			Console.WriteLine("\nОбъект класса Point с параметрами, заполнение с помощью датчика случайных чисел: ");
			double lowerBoundary, upperBoundary;
			Program.InputDoubleBoundaries(out lowerBoundary, out upperBoundary, "Введите границы диапазона датчика случайных чисел: ");
			double randomX = Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4), randomY = Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4);
			Point pointWithRandomParams = new Point(randomX, randomY);
			pointWithRandomParams.Show();
			pointWithRandomParams.ShowLength();
			
			Console.WriteLine("\nОбъект класса Point с параметрами, заполнение с помощью пользовательского ввода: ");
			double userX = Input.TypeDouble("Введите значение координаты x: "), userY = Input.TypeDouble("Введите значение координаты y: ");
			userX = Math.Round(userX, 4); userY = Math.Round(userY, 4);
			Console.WriteLine("Округление до 4 знаков после запятой");
			Point pointWithUserParams = new Point(userX, userY);
			pointWithUserParams.Show();
			pointWithUserParams.ShowLength();

			Console.WriteLine("\nОбъект класса Point, созданный с помощью конструктора копирования\nВ параметрах - объект класса Pont, созданный с помощью датчика случайных чисел: ");
			Point pointCopy = new Point(pointWithRandomParams);
			pointCopy.Show();
			pointCopy.ShowLength();

			Console.WriteLine($"\nКоличество созданных объектов класса Point = {Point.Counter}\n");
			Console.WriteLine("----- 1 часть завершена -----\n");

		}

        public void MenuSecondPart()
        {
			Console.WriteLine("----- 2 часть -----\n");
			int userChoise;
			do
			{
				Console.WriteLine("Выберите способ ввода объекта класса: ");
				Console.WriteLine("1. Ввод пользователя\n" +
					  "2. Ввод с помощью датчика случайных чисел\n" +
					  "0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
				Console.WriteLine("");
				double x, y, doublePoint, result;
				int intPoint;
				Point tempPoint = new Point(1, 1);
				Point pointSecondPart;
				switch (userChoise)
				{
					case 1:
						Console.WriteLine("Создание объекта класса Point с помощью пользовательского ввода\n");
						x = Input.TypeDouble("Введите координату x: ");
						y = Input.TypeDouble("Введите координату y: ");
						x = Math.Round(x, 4);
						y = Math.Round(y, 4);
						pointSecondPart = new Point(x, y);
						pointSecondPart.Show();

						Console.WriteLine("\nПерегрузка унарных операций");
						Console.WriteLine("Перегрузка оператора --");
						--pointSecondPart;
						pointSecondPart.Show();
						pointSecondPart = -pointSecondPart;
						pointSecondPart.Show();

						Console.WriteLine("\nОперации приведения типов");
						Console.WriteLine("Неявное приведение типа int");
						intPoint = pointSecondPart;
						Console.WriteLine($"intPoint = {intPoint}\n");
						Console.WriteLine("Явное приведение типа double");
						doublePoint = (double)pointSecondPart;
						Console.WriteLine($"doublePoint = {doublePoint}\n");

						Console.WriteLine("Перегрузка бинарных операций");
						Console.WriteLine("Перегрузка оператора - (Point - int)");
						pointSecondPart = pointSecondPart - 3;
						pointSecondPart.Show();
						Console.WriteLine("Перегрузка оператора - (int - Point)");
						pointSecondPart = 3 - pointSecondPart;
						pointSecondPart.Show();
						Console.WriteLine("Перегрузка оператора - (Point - Point)");
						result = pointSecondPart - tempPoint;
						Console.WriteLine($"Расстояние между двумя точками = {result}");
						Console.WriteLine("----- 2 часть завершена -----\n");
						break;
					case 2:
						Console.WriteLine("Создание объекта класса Point с помощью датчика случайных чисел\n");
						double lowerBoundary, upperBoundary;
						Program.InputDoubleBoundaries(out lowerBoundary, out upperBoundary, "Введите границы диапазона датчика случайных чисел: ");
						x = Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4);
						y = Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4);
						pointSecondPart = new Point(x, y);
						pointSecondPart.Show();

						Console.WriteLine("Перегрузка унарных операций");
						Console.WriteLine("Перегрузка оператора --");
						--pointSecondPart;
						pointSecondPart.Show();
						pointSecondPart = -pointSecondPart;
						pointSecondPart.Show();

						Console.WriteLine("Операции приведения типов");
						Console.WriteLine("Неявное приведение типа int");
						intPoint = pointSecondPart;
						Console.WriteLine("Явное приведение типа double");
						doublePoint = (double)pointSecondPart;

						Console.WriteLine("Перегрузка бинарных операций");
						Console.WriteLine("Перегрузка оператора - (Point - int)");
						pointSecondPart = pointSecondPart - 3;
						pointSecondPart.Show();
						Console.WriteLine("Перегрузка оператора - (int - Point)");
						pointSecondPart = 3 - pointSecondPart;
						pointSecondPart.Show();
						Console.WriteLine("Перегрузка оператора - (Point - Point)");
						result = pointSecondPart - tempPoint;
						Console.WriteLine($"Расстояние между двумя точками = {result}");
						Console.WriteLine("----- 2 часть -----\n");
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Неизвестная функция");
						break;
				}
			} while (userChoise != 0);
			Console.WriteLine($"Количество вызванных объектов = {Point.Counter}");
			Console.WriteLine("----- 2 часть завершена -----\n");
		}

        public void MenuThirdPart()
        {
				Console.WriteLine("----- 3 часть -----\n");
				int userChoise, size, index;
				do
				{
					Console.WriteLine("Выберите конструктор для создания объектов коллекции класса Point: ");
					Console.WriteLine("1. Конструктор с пользовательским вводом\n" +
						  "2. Конструктор с использованием датчика случайных чисел\n" +
						  "3. Конструктор без параметров\n" +
						  "0. Выход\n");
					userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
					Console.WriteLine("");

					switch (userChoise)
					{
						case 1:
							Console.WriteLine("Конструктор с пользовательским вводом");
							size = Input.TypePositiveInteger("Введите размер массива: ");
							(double, double)[] arrayPoints = new (double, double)[size];
							for (int i = 0; i < arrayPoints.Length; ++i)
							{
								arrayPoints[i].Item1 = Input.TypeDouble($"Введите координату x {i + 1} точки: ");
								arrayPoints[i].Item1 = Math.Round(arrayPoints[i].Item1, 4);
								arrayPoints[i].Item2 = Input.TypeDouble($"Введите координату y {i + 1} точки: ");
								arrayPoints[i].Item2 = Math.Round(arrayPoints[i].Item2, 4);
							}

							PointArray userPointArray = new PointArray(size, arrayPoints);
							userPointArray.ShowPointArray();
							Program.GetMinimalLength(userPointArray);
							index = Input.TypeInteger("Введите индекс элемента: ");
							Console.WriteLine(userPointArray[index]);
							break;
						case 2:
							Console.WriteLine("Конструктор с использованием датчика случайных чисел");
							double lowerBoundary, upperBoundary;
							size = Input.TypePositiveInteger("Введите размер массива: ");
							Program.InputDoubleBoundaries(out lowerBoundary, out upperBoundary, "Введите границы диапазона датчика случайных чисел: ");
							PointArray randomPointArray = new PointArray(size, lowerBoundary, upperBoundary);
							randomPointArray.ShowPointArray();
							Program.GetMinimalLength(randomPointArray);
							index = Input.TypeInteger("Введите индекс элемента: ");
							Console.WriteLine(randomPointArray[index]);
							break;
						case 3:
							Console.WriteLine("Конструктор без параметров");
							PointArray pointArrayWithoutParams = new PointArray();
							pointArrayWithoutParams.ShowPointArray();
							Program.GetMinimalLength(pointArrayWithoutParams);
							index = Input.TypeInteger("Введите индекс элемента: ");
							Console.WriteLine(pointArrayWithoutParams[index]);
							break;
						case 0:
							break;
						default:
							Console.WriteLine("Неизвестная функция");
							break;
					}
				} while (userChoise != 0);
			Console.WriteLine($"Количество вызванных объектов = {Point.Counter}");
			Console.WriteLine("----- 3 часть завершена -----\n");
		}

        public void MainMenu()
        {
            int userChoise;
			do
			{
				Console.WriteLine("1. Первая часть\n" +
					  "2. Вторая часть\n" +
					  "3. Третья часть\n" +
					  "0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
				Console.WriteLine("");
				switch (userChoise)
				{
					case 1:
						MenuFirstPart();
						break;
					case 2:
						MenuSecondPart();
						break;
					case 3:
						MenuThirdPart();
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Неизвестная функция");
						break;
				}
			} while (userChoise != 0);
		}
    }
}
