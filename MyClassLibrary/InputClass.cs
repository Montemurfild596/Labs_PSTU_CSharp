using System;

namespace MyClassLibrary
{
	public class Input
	{
		public static int TypeInteger(string message)
		{
			string buf;
			int result;
			bool isCorrectInput = false;
			do
			{
				Console.Write(message);
				buf = Console.ReadLine();
				isCorrectInput = Int32.TryParse(buf, out result);
				if (!isCorrectInput)
				{
					Console.WriteLine("Ошибка: введённое значение не соответствует типу integer");
				}
			} while (!isCorrectInput);
			return result;
		}
		public static int TypePositiveInteger(string message)
        {
			string buf;
			int result;
			bool isCorrectInput = false, isPositive = true;
			do
			{
				Console.Write(message);
				buf = Console.ReadLine();
				isCorrectInput = Int32.TryParse(buf, out result);
				if (!isCorrectInput)
				{
					Console.WriteLine("Ошибка: введённое значение не соответствует типу integer");
				}
				else
				{
					isPositive = result > 0;
					if (!isPositive)
					{
						Console.WriteLine("Ошибка: введённое значение не положительное");
					}
				}
			} while (!isCorrectInput || !isPositive);
			return result;
        }
		public static double TypeDouble(string message)
		{
			string buf;
			double result;
			bool isCorrectInput = false, isCorrectFormula = false;
			do
			{
				Console.Write(message);
				buf = Console.ReadLine();
				isCorrectInput = Double.TryParse(buf, out result);
				if (!isCorrectInput)
				{
					Console.WriteLine("Ошибка: введённое значение не соответствует типу double");
				}
				else if (result > 2 || result < 0)
                {
					Console.WriteLine("Значение выражение от данного аргумента не может быть вычислено");
                }
				isCorrectFormula = result > 0 || result < -2;
			} while (!isCorrectInput || isCorrectFormula);
			return result;
		}
		public static float TypeFloat(string message)
		{
			string buf;
			float result;
			bool isCorrect = false;
			do
			{
				Console.Write(message);
				buf = Console.ReadLine();
				isCorrect = Single.TryParse(buf, out result);

				if (!isCorrect)
				{
					Console.WriteLine("Ошибка: введЁнное значение не соответствует типу float");
				}
			} while (!isCorrect);
			return result;
		}
		public static T ChoiceOfTwoValues<T>(T first, T second, string message)
		{
			string buf;
			T result = first;
			bool isCorrect = false;
			do
			{
				Console.WriteLine(message);
				buf = Console.ReadLine();
				isCorrect = buf == first.ToString() || buf == second.ToString();
				if (buf == first.ToString())
				{
					result = first;
				}
				else if (buf == second.ToString())
				{
					result = second;
				}
				else
				{
					Console.WriteLine("Ошибка: введённое значение не соответсвует ни одному из двух вариантов");
				}
			} while (!isCorrect);
			return result;
		}
	}


	public class Figure2f
	{
		public class Point2f
		{
			public float x = 0, y = 0;
			public Point2f()
            {
				this.x = 0;
				this.y = 0;
            }
			public Point2f(float x, float y)
            {
				this.x = x;
				this.y = y;
            }
		}
		public class Triangle
		{
			public static bool PointBelongingToTriangle(Point2f first, Point2f second, Point2f third, Point2f targetPoint)
			{
				float result1 = (first.x - targetPoint.x) * (second.y - first.y) - (second.x - first.x) * (first.y - targetPoint.y);
				float result2 = (second.x - targetPoint.x) * (third.y - second.y) - (third.x - second.x) * (second.y - targetPoint.y);
				float result3 = (third.x - targetPoint.x) * (first.y - third.y) - (first.x - third.x) * (third.y - targetPoint.y);
				bool isPositive = result1 >= 0 && result2 >= 0 && result3 >= 0, isNegative = result1 <= 0 && result2 <= 0 && result3 <= 0;
				return isPositive || isNegative;
			}
		}
		public class Circle
		{
			public static bool PointBelongingToCircle(Point2f center, float radius, Point2f targetPoint)
			{
				float result = MathF.Pow((targetPoint.x - center.x), 2) + MathF.Pow((targetPoint.y - center.y), 2) - MathF.Pow(radius, 2);
				bool isResult = (result <= 0);
				return isResult;
			}

		}
	}
}
