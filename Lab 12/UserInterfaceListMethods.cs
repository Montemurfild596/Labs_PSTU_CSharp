using LabClassLibrary;
using MyClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_12
{
	public partial class UserInterface
	{
		public static Item InputItem()
		{
			int userChoise = -1;
			int weight, cost, date;
			string name;
			do
			{
				Console.WriteLine("Возможные объекты:\n" +
				"1. Предмет\n" +
				"2. Продукт\n" +
				"3. Молочный продукт\n" +
				"4. Игрушка\n");
				userChoise = Input.TypeInteger("Выберите один из объектов: ");
				

				switch (userChoise)
				{
					case 1:
						weight = Input.TypePositiveInteger("Введите массу предмета: ");
						cost = Input.TypePositiveInteger("Введите стоимость предмета: ");
						Item item = new Item(weight, cost);
						return item;
					case 2:
						weight = Input.TypePositiveInteger("Введите массу предмета: ");
						cost = Input.TypePositiveInteger("Введите стоимость предмета: ");
						date = Input.TypePositiveInteger("Введите срок хранения в днях: ");
						Product product = new Product(weight, cost, date);
						return product;
					case 3:
						weight = Input.TypePositiveInteger("Введите массу предмета: ");
						cost = Input.TypePositiveInteger("Введите стоимость предмета: ");
						date = Input.TypePositiveInteger("Введите срок хранения в днях: ");
						Console.WriteLine("Введите название молочного продукта: ");
						name = Console.ReadLine()!;
						MilkProduct milkProduct = new MilkProduct(weight, cost, date, name);
						return milkProduct;
					case 4:
						weight = Input.TypePositiveInteger("Введите массу предмета: ");
						cost = Input.TypePositiveInteger("Введите стоимость предмета: ");
						Console.WriteLine("Введите название молочного продукта: ");
						name = Console.ReadLine()!;
						Toy toy = new Toy(weight, cost, name);
						return toy;
					default:
						Console.WriteLine("Неизвестный объект\n");
						break;
				}
			} while (true);
		}
		static public void CreateDeList(ref DeList delist)
		{
			int userChoise = -1;
			do
			{
				Console.WriteLine("Возможные функции:\n" +
				"1. Создание пустого двунаправленного списка\n" +
				"2. Создание двунаправленного списка с начальным элементом\n" +
				"3. Создание двунаправленного списка с заданным количеством элементов\n" +
				"0. Выход\n");
				userChoise = Input.TypeInteger("Выберите одну из возможных функций: ");
				switch (userChoise)
				{
					case 1:
						Console.WriteLine("Создание пустого двунаправленного списка\n");
						delist = new DeList();
						break;
					case 2:
						Console.WriteLine("Создание двунаправленного списка с начальным элементом\n");
						delist = new DeList(InputItem());
						break;
					case 3:
						Console.WriteLine("Создание двунаправленного списка с заданным количеством элементов\n");
						delist = new DeList(Input.TypeInteger("Введите размер двунаправленного списка: "));
						break;
					case 0:
						Console.WriteLine("Выход\n");
						break;
					default:
						Console.WriteLine("Неизвестная функция\n");
						break;
				}
			} while (userChoise < 0 && userChoise > 3);
		}
		static public void AddDeList(ref DeList delist)
		{

		}
	}
}
