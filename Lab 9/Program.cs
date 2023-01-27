using System;
using static MyClassLibrary.Input;

namespace Lab_9
{
    class Program
    {
        public static double GetLength(Point p1)
        {
            double result = Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
            return result;
        }

		public static void InputDoubleBoundaries(out double a, out double b, string message)
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

		public static void GetMinimalLength(PointArray pointMas)
        {
			if (pointMas.Length > 0)
            {
				double result = pointMas[0].GetLength();
				int indexMinimalLength = 0;
				for (int i = 0; i < pointMas.Length; ++i)
                {
					if (result >= pointMas[i].GetLength())
					{
						indexMinimalLength = i;
						result = pointMas[i].GetLength();
					}
                }
				Console.WriteLine($"Минимальное расстояние от точки до начала координат у {indexMinimalLength + 1} точки, длина = {result}");
            }
			else
            {
				Console.WriteLine("Поиск минимального расстояния невозможен");
            }
        }

		static void Main(string[] args)
        {
			PointArray temp1 = new PointArray(10, 10, 100);
            PointArray temp2 = new PointArray(10, 10, 100);
            Menu menu = new Menu();
			menu.MainMenu();
        }
    }
}
