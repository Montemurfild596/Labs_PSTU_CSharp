using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
	public partial class UserInterface
	{
		static public void ListTask(ref DeList delist)
		{
			Console.WriteLine("Работа с реализованным списком");
			int userChoise = -1;
			do
			{
				Console.WriteLine("Доступные функции:\n" +
					"1. Создание двунаправленного списка\n" +
					"2. Вывод двунаправленного списка\n" +
					"3. Добавление элемента в список\n" +
					"4. Удаление элемента(ов) из списка\n" +
					"5. Поиск заданного объекта в списке\n" +
					"0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из доступных функций: ");
				switch (userChoise)
				{
					case 1:
						Console.WriteLine("Создание двунаправленного списка\n");
						CreateDeList(ref delist);
						break;
					case 2:
						Console.WriteLine("Вывод двунаправленного списка\n");
						delist.Print();
						break;
					case 3:
						Console.WriteLine("Добавление элемента в список\n");
						AddDeList(ref delist);
						break;
					case 4:
						Console.WriteLine("Удаление элемента(ов) из списка\n");

						break;
					case 5:
						Console.WriteLine("Поиск заданного элемента в списке\n");

						break;
					case 0:
						break;
					default:
						Console.WriteLine("Неизвестная функция!");
						break;
				}
			} while (userChoise != 0);
		}
	}
}
