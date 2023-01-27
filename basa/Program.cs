using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoddamnArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк массива: ");
            var numberOfLines = Convert.ToInt32(Console.ReadLine());
            float[][] array = new float[numberOfLines][];
            for (int i = 0; i < numberOfLines; i++)
            {
                Console.Write($"Введите количество элементов в {i} строке: ");
                var lengthOfLine = Convert.ToInt32(Console.ReadLine());
                array[i] = new float[lengthOfLine];
            }
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write($"Введите {j} элемент {i} строки: ");
                    array[i][j] = Convert.ToSingle(Console.ReadLine());
                }
            }
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Введите значение нового элемента: ");
            var addedNumber = Convert.ToSingle(Console.ReadLine());
            int addedNumberLine;
            while (true)
            {
                Console.Write($"Введите номер строки нового элемента (целое число от 0 до {numberOfLines - 1}): ");
                addedNumberLine = Convert.ToInt32(Console.ReadLine());
                if (addedNumberLine >= 0 && addedNumberLine < numberOfLines) break;
                Console.WriteLine("Номер строки находится за пределами массива.");
            }
            int previousNumberPosition;
            while (true)
            {
                Console.Write($"Введите номер элемента перед новым (целое число от 0 до {array[addedNumberLine].Length - 1}): ");
                previousNumberPosition = Convert.ToInt32(Console.ReadLine());
                if (previousNumberPosition >= 0 && previousNumberPosition < array[addedNumberLine].Length) break;
                Console.WriteLine("Номер элемента находится за пределами массива.");
            }
            float[] arrayAddNumber = new float[array[addedNumberLine].Length + 1];
            for (int j = 0; j < arrayAddNumber.Length; j++)
            {
                if (j > previousNumberPosition)
                {
                    arrayAddNumber[j] = array[addedNumberLine][j - 1];
                    if (j == previousNumberPosition + 1) arrayAddNumber[j] = addedNumber;
                }
                else arrayAddNumber[j] = array[addedNumberLine][j];
            }
            array[addedNumberLine] = arrayAddNumber;
            for (int i = 0; i < numberOfLines; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            float[][] arrayTemp = array;
            array = new float[numberOfLines + 1][];
            Console.Write("Введите количество элементов новой строки: ");
            var addedLineLength = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= numberOfLines; i++)
            {
                if (i == numberOfLines) array[i] = new float[addedLineLength];
                else array[i] = new float[arrayTemp[i].Length];
            }
            for (int i = 0; i <= numberOfLines; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i == numberOfLines)
                    {
                        Console.Write($"Введите {j} элемент новой строки: ");
                        array[i][j] = Convert.ToSingle(Console.ReadLine());
                    }
                    else array[i][j] = arrayTemp[i][j];
                }
            }
            for (int i = 0; i <= numberOfLines; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
