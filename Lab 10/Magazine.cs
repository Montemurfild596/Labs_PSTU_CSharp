using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
    public class Magazine : ICloneable, IRandomInit
	{
		protected static readonly string[] names = { "Пятёрочка", "Магнит", "Перекрёсток", "Лента" };
		private string name;
		public string Name
		{
			get 
			{ 
				return name; 
			}
			private set
			{
				name = value;
			}
		}
		public Item[] items { get; set; }

		public Magazine()
		{
			this.RandomInit();
		}
		
        public override string ToString()
        {
            string result = $"Товары магазина {this.Name}:\n";
            for (int i = 0; i < items.Length; ++i)
            {
                if (items[i] != null)
                    result += $"\t{i}. " + items[i].ToString() + '\n';
                else
                    result += "\tNULL\n";
            }
            return result;
        }
        public static Item[] getItems()
		{
			Random rnd = new Random();
			Item[] items = new Item[rnd.Next(10, 20)];
			for (int i = 0; i < items.Length; i++)
			{
				switch (rnd.Next(0, 4))
				{
					case 0:
						items[i] = new Item();
						break;
					case 1:
						items[i] = new Product();
						break;
					case 2:
						items[i] = new Toy();
						break;
					case 3:
						items[i] = new MilkProduct();
						break;
				}
			}
			return items;
		}
		public object Clone()
		{
			Magazine m = new Magazine();
			m.name = name;
			Item[] itemMas = new Item[this.items.Length];
			for (int i = 0; i < itemMas.Length; ++i)
			{
				itemMas[i] = this.items[i].Clone() as Item;
			}
			m.items = itemMas;
			return m;
		}

		public Magazine ShallowCopy()
		{
			return (Magazine)this.MemberwiseClone();
		}

		public void RandomInit()
		{
			Random rnd = new Random();
			this.name = names[rnd.Next(0, names.Length)];
			this.items = getItems();
			Array.Sort(this.items);
		}

		public void FindCheapToy()
		{
			Console.WriteLine("Поиск объекта Toy с минимальной стоимостью");
			int minIndex = 0;
			int minCost = int.MaxValue;
			string name = "";
			if (items.Length > 0)
			{
				for (int i = 0; i < items.Length; i++)
				{
					Toy t = items[i] as Toy;
					if (t != null)
					{
						if (t.Cost < minCost)
						{
							minCost = t.Cost;
							minIndex = i;
							name = t.Name;
						}
					}
				}
				Console.WriteLine($"Самая дешёвая игрушка называется {name}, стоит {minCost}");
			}
			else
			{
				Console.WriteLine("Невозможно выполнить запрос, так как массив пустой");
			}
		}

		public void FindCountMilkProduct()
		{
			Console.WriteLine("Поиск количества объектов типа MilkProduct");
			int count = 0;
			if (items.Length > 0)
			{
				for (int i = 0; i < items.Length; i++)
				{
					MilkProduct t = items[i] as MilkProduct;
					if (t != null)
					{
						++count;
					}
				}
				Console.WriteLine($"В массиве {count} объектов типа MilkProduct");
			}
			else
			{
				Console.WriteLine("Невозможно выполнить запрос, так как массив пустой");
			}
		}

		public void PrintProducts()
		{
			Console.WriteLine("Вывод всех объектов типа Product");
			int count = 0;
			if (items.Length > 0)
			{
				for (int i = 0; i < items.Length; i++)
				{
					Product t = items[i] as Product;
					if (t != null)
					{
                        Console.WriteLine(t);
                    }
				}
			}
			else
			{
				Console.WriteLine("Невозможно выполнить запрос, так как массив пустой");
			}
		}
    }
}
