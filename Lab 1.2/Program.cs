using MyClassLibrary;
using System;

namespace Lab_1._2
{
	class Program
	{1
		static void Main(string[] args)
		{
			// треугольник равнобедренный: точки - 0:5; 10:0; 0:-5
			// эллипс: центр - 5:0; a = 5, b = 5 => неправильный рисунок, фигура - круг: (x - 5)^2 + y^2 = 25
			Figure2f.Point2f[] trianglePoints = new Figure2f.Point2f[3] /*{ {0, 5}, {10, 0}, {0, -5} }*/;
			trianglePoints[0] = new Figure2f.Point2f(0, 5);
			trianglePoints[1] = new Figure2f.Point2f(10, 0);
			trianglePoints[2] = new Figure2f.Point2f(0, -5);
			float radius = 5;
			Figure2f.Point2f center = new(5, 0);
			Figure2f.Point2f targetPoint = new(Input.TypeFloat("Введите координату x: "), Input.TypeFloat("Введите координату y: "));
			bool result_1 = Figure2f.Triangle.PointBelongingToTriangle(trianglePoints[0], trianglePoints[1], trianglePoints[2], targetPoint);
			bool result_2 = Figure2f.Circle.PointBelongingToCircle(center, radius, targetPoint);
			Console.WriteLine((result_1 || result_2));
		}
	}
}
