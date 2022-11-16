using System;
using MyClassLibrary;

namespace Lab_6
{
    class Program
    {
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



		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
