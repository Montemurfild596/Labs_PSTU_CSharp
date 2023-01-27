using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
	public class PointArray
	{
		#region Атрибуты

		Point[] mas = null;
		static Random rnd = new Random();

		#endregion

		#region Конструкторы

		public PointArray()
        {
			mas = new Point[0];
        }

		public PointArray(int size, double lowerBoundary, double upperBoundary)
		{
			if (size >= 0)
			{
				mas = new Point[size];
				for (int i = 0; i < this.Length; ++i)
				{
					Point p = new Point(Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4), Math.Round(rnd.NextDouble() * (upperBoundary - lowerBoundary) + lowerBoundary, 4));
					mas[i] = p;
				}
			} 
			else
            {
				Console.WriteLine("Ошибка: размер меньше нуля");
            }
        }

		public PointArray(int size, params (double x, double y)[] list)
        {
			if (size >= 0)
            {
				mas = new Point[size];

				for (int i = 0; i < this.Length; ++i)
                {
					Point p = new Point(Math.Round(list[i].x, 4), Math.Round(list[i].y, 4));
					mas[i] = p;
                }
            }
			else
			{
				Console.WriteLine("Ошибка: размер меньше нуля");
			}
		}

		public PointArray(PointArray temp)
        {
			this.mas = new Point[temp.Length];
			for (int i = 0; i < this.mas.Length; ++i)
            {
				this.mas[i] = temp[i];
            }
        }

		#endregion

		#region Свойства

		public int Length
		{
			get => mas.Length;
		}

        #endregion

        #region

		public static bool operator ==(PointArray temp1, PointArray temp2)
		{
			bool isEqual = true;
			if (temp1.Length == temp2.Length)
			{
				for (int i = 0; i < temp1.Length && i < temp2.Length && isEqual; ++i)
				{
					isEqual = (temp1[i] == temp2[i]);
				}
			} 
			else
			{
				isEqual = false;
			}
			return isEqual;
		}

        public static bool operator !=(PointArray temp1, PointArray temp2)
        {
            bool isNotEqual = false;
            for (int i = 0; i < temp1.Length && i < temp2.Length && !isNotEqual; ++i)
            {
                isNotEqual = (temp1[i] != temp2[i]);
            }

            return isNotEqual;
        }

        public override bool Equals(object obj)
        {
            if (obj is PointArray pointArray)
			{
				return this == pointArray;
			}
			return false;
        }

        #endregion

        #region Индексатор

        public Point this[int index]
        {
			get
            {
				if (index >= 0 && index < mas.Length)
					return mas[index];
				throw new ArgumentException("Исключение: выход за границу массива");
			}
			set
            {
				if (index >= 0 && index < mas.Length)
					mas[index] = value;
				else Console.WriteLine("Выход за границу массива");
            }
        }

        #endregion

        #region Вывод

        public void ShowPointArray()
        {
			Console.WriteLine("-----Вывод массива точек-----");
			if (this.Length > 0)
            {
				for (int i = 0; i < this.Length; ++i)
                {
					Console.Write($"Точка {i + 1}: ");
					mas[i].Show();
                }
            }
			else
            {
				Console.WriteLine("Вывод массива невозможен, так как размер неположительный");
            }
			Console.WriteLine("-----Вывод массива точек завершён-----");
		}

		#endregion
	}
}
