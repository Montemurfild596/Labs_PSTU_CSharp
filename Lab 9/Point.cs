using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
	public class Point
	{
		#region Атрибуты

		private double x;
		private double y;
		private static int counter = 0;

		#endregion

		#region Свойства
		public double X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		public double Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		public static int Counter => counter;

		#endregion

		#region Конструкторы

		public Point()
		{
			this.X = 0;
			this.Y = 0;
			counter++;
		}

		public Point(double x, double y)
		{
			this.X = x;
			this.Y = y;
			counter++;
		}

		public Point(Point temp)
		{
			this.X = temp.X;
			this.Y = temp.Y;
			counter++;
		}

		#endregion

		#region Выводы
		public void Show()
		{
			Console.WriteLine($"[{this.X} : {this.Y}]");
		}

		public void ShowLength()
		{
			Console.WriteLine($"Расстояние от точки до начала координат = {GetLength()}");
		}

		#endregion

		public double GetLength()
		{
			double result = Math.Sqrt(this.X * this.X + this.Y * this.Y);
			return result;
		}

		#region Перегрузки операторов

		#region Перегрузка унарных операторов

		public static Point operator --(Point p)
		{
			p.X -= 1;
			p.Y -= 1;
			return p;
		}

		public static Point operator -(Point p)
		{
			(p.X, p.Y) = (p.Y, p.X);
			return p;
		}

		#endregion

		#region Операции приведения типа

		public static implicit operator int(Point p)
		{
			return Convert.ToInt32(p.X);
		}

		public static explicit operator double(Point p)
		{
			return p.Y;
		}

		#endregion

		#region Перегрузка бинарных операторов

		public static Point operator -(Point p, int temp)
		{
			p.X -= temp;
			p.X = Math.Round(p.X, 4);
			p.Y = Math.Round(p.Y, 4);
			return p;
		}
		
		public static Point operator -(int temp, Point p)
		{
			p.Y -= temp;
            p.X = Math.Round(p.X, 4);
            p.Y = Math.Round(p.Y, 4);
            return p;
		}

		public static double operator -(Point firstPoint, Point secondPoint)
		{
			double result = Math.Sqrt( (firstPoint.X - secondPoint.X) * (firstPoint.X - secondPoint.X) - (firstPoint.Y - secondPoint.Y) * (firstPoint.Y - secondPoint.Y) );
			return result;
		}

		public static bool operator ==(Point firstPoint, Point secondPoint)
		{
			double temp1 = firstPoint.X - secondPoint.X;
			double temp2 = firstPoint.Y - secondPoint.Y;

			if (Math.Abs(temp1) <= 0.000001 && Math.Abs(temp2) <= 0.000001)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(Point firstPoint, Point secondPoint)
		{
            double temp1 = firstPoint.X - secondPoint.X;
            double temp2 = firstPoint.Y - secondPoint.Y;
            if (Math.Abs(temp1) <= 0.000001 || Math.Abs(temp2) <= 0.000001)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is Point point)
			{
				return this == point;
			}
			return false;
		}

		#endregion

		#endregion

	}
}
