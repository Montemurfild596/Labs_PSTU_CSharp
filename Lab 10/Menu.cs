using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary;

namespace Lab_10
{
	class Menu
	{
		Random rnd = new Random();
		public static void MenuFirstPart(Magazine magazine)
		{
			int userChoice = 0;
			do
			{
				Console.WriteLine("1. Вывод массива с помощью переопределния виртуальной функции ToString()\n" +
                    "2. Вывод массива без виртуальных функций\n" +
					"0. Выход\n");
				userChoice = Input.TypeInteger("Введите номер команды: ");
				switch (userChoice)
				{
					case 1:
						Console.Write(magazine);
						break;
					case 2:
                        string result = $"Товары магазина {magazine.Name}:\n";
                        for (int i = 0; i < magazine.items.Length; ++i)
                        {
                            if (magazine.items[i] != null)
                                result += $"\t{i}. " + magazine.items[i].NoVirtualToString() + '\n';
                            else
                                result += "\tNULL\n";
                        }
                        Console.Write(result);
                        break;
                    case 0:
						break;
					default:
						Console.WriteLine("Неизвестная команда");
						break;
				}
			} while (userChoice != 0);
		}

		public static void MenuSecondPart(Magazine magazine)
		{
			int userChoice = 0;
			do
			{
				Console.WriteLine("1. Поиск объекта Toy с минимальной стоимостью\n" +
					"2. Поиск количества объектов типа MilkProduct\n" +
					"3. Вывод всех объектов типа Product\n" +
					"0. Выход\n");
				userChoice = Input.TypeInteger("Введите номер команды: ");
				switch (userChoice)
				{
					case 1:
                        magazine.FindCheapToy();
						break;
					case 2:
                        magazine.FindCountMilkProduct();
						break;
					case 3:
                        magazine.PrintProducts();
						break;
					case 0:
						break;
					default:
						Console.WriteLine("Неизвестная команда");
						break;
				}
			} while (userChoice != 0);

		}

		public static void MenuThirdPart(IRandomInit[] randoms, ref Magazine magazine, Magazine shallow_magazine, Magazine deep_magazine)
		{
			int userChoise;
			do
			{
				Console.WriteLine("1. Сгенерировать и вывести массив элементов IRandomInit\n" +
                      "2. Сортировка массива по стоимости с помощью интерфейса IComparable\n" +
                      "3. Сортировка массива по стоимости с помощью интерфейса ICompare и поиск предмета с помощью перегрузки метода Equals\n" +
                      "4. Разница между поверхностным и глубоким копированием\n" +
					  "0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из предложенных функций: ");
				Console.WriteLine("");

				switch (userChoise)
				{
					case 1:
						for (int i = 0; i < randoms.Length; ++i)
						{
							Console.WriteLine(i.ToString() + ". " + randoms[i].ToString());
						}
						break;
					case 2:
						Console.Write(magazine);
						break;
					case 3:
                        Array.Sort(magazine.items, new SortByCost());
                        Console.Write(magazine);
                        int weight, cost;
                        weight = Input.TypeInteger("Введите массу предмета: ");
                        cost = Input.TypeInteger("Введите стоимость предмета: ");
                        Console.WriteLine($"Индекс этого предмета в массиве: {Array.IndexOf(magazine.items, new Item(weight, cost))}\n");
                        Array.Sort(magazine.items);
                        break;
                    case 4:
                        Console.WriteLine("Изначальный объект, переменная `magazine` типа Magazine:\n");
                        Console.Write(magazine);
                        Console.WriteLine("Поверхностная копия, переменная `shallow_magazine` типа Magazine:\n");
                        Console.Write(shallow_magazine);
                        Console.WriteLine("Глубокая копия, переменная `deep_magazine` типа Magazine:\n");
                        Console.Write(deep_magazine);
                        for (int i = 0; i < magazine.items.Length; ++i)
                            magazine.items[i] = null;
                        Console.WriteLine("Все элементы массива в переменной `magazine` заменены на null =>\n");
                        Console.WriteLine("Изначальный объект, переменная `magazine` типа Magazine:\n");
                        Console.Write(magazine);
                        Console.WriteLine("Поверхностная копия, переменная `shallow_magazine` типа Magazine:\n");
                        Console.Write(shallow_magazine);
                        Console.WriteLine("Глубокая копия, переменная `deep_magazine` типа Magazine:\n");
                        Console.Write(deep_magazine);
                        magazine = (Magazine)deep_magazine.Clone();
                        randoms[randoms.Length - 1] = magazine;
                        shallow_magazine = magazine.ShallowCopy();
                        break;
					default:
						Console.WriteLine("Неизвестная команда");
						break;
				}
			} while (userChoise != 0);
		}

		public static void MainMenu()
		{
			Magazine magazine = new Magazine();
			Magazine shallow_magazine = magazine.ShallowCopy();
			Magazine deep_magazine = (Magazine)magazine.Clone();
			IRandomInit[] randoms = new IRandomInit[magazine.items.Length + 1];
			for (int i = 0; i < randoms.Length - 1; ++i)
			{
				randoms[i] = magazine.items[i].Clone() as Item;
			}
			randoms[randoms.Length - 1] = magazine;

            int userChoice = 0;
            do
            {
                Console.WriteLine("1. 1 часть\n" +
                    "2. 2 часть\n" +
                    "3. 3 часть\n" +
                    "0. Выход\n");
                userChoice = Input.TypeInteger("Введите номер команды: ");
                switch (userChoice)
                {
                    case 1:
						MenuFirstPart(magazine);
                        break;
                    case 2:
                        MenuSecondPart(magazine);
                        break;
                    case 3:
                        MenuThirdPart(randoms, ref magazine, shallow_magazine, deep_magazine);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            } while (userChoice != 0);
        }
	}
}
