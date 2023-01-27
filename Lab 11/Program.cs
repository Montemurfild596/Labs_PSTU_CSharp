using System;
using MyClassLibrary;

namespace Lab_11
{
    public class Program
    {

        #region Работа с очередью

        public static Queue<Item> GenerateQueue()
        {
            Random rnd = new Random();
            int len = rnd.Next(4, 6);
            Queue<Item> persons = new Queue<Item>();
            for (int i = 0; i < len; ++i)
            {
                switch (rnd.Next(0, 4))
                {
                    case 0:
                        persons.Enqueue(new Item());
                        break;
                    case 1:
                        persons.Enqueue(new Product());
                        break;
                    case 2:
                        persons.Enqueue(new MilkProduct());
                        break;
                    case 3:
                        persons.Enqueue(new Toy());
                        break;
                }
            }
            return persons;
        }

        public static void SortQueue(ref Queue<Item> items)
        {
            Item[] it = items.ToArray();
            Array.Sort(it);
            Queue<Item> result = new Queue<Item>();
            for (int i = 0; i < it.Length; ++i)
            {
                result.Enqueue(it[i]);
            }
            items = result;
        }

        //вывод очереди
        public static void DisplayQueue(Queue<Item> items)
        {
            if (items.Count != 0)
            {
                string result = "";
                int counter = 0;
                foreach (Item p in items)
                {
                    if (p != null)
                        result += $"\t{counter}. " + p.ToString() + '\n';
                    else
                        result += "\tNULL\n";
                    ++counter;
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Очередь пуста!\n");
            }
        }

        //вывод всех элементов определённого типа в очереди и их количества
        public static void DisplayTypeInQueue(Queue<Item> items, Type t)
        {
            int counter = 0;
            int index = 0;
            if (t == typeof(Item))
            {
                Console.WriteLine("Элементы типа Item: ");
                foreach (Item it in items)
                {
                    if (it != null && !(it is Product) && !(it is Toy))
                    {
                        Console.WriteLine(index.ToString() + ". " + it.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа Item: " + counter);
            }
            else if (t == typeof(Product))
            {
                Console.WriteLine("Элементы типа Product: ");
                foreach (Item it in items)
                {
                    if (it != null && it is Product && !(it is MilkProduct))
                    {
                        Console.WriteLine(index.ToString() + ". " + it.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа Product: " + counter);
            }
            else if (t == typeof(Toy))
            {
                Console.WriteLine("Элементы типа Toy: ");
                foreach (Item it in items)
                {
                    if (it != null && it is Toy)
                    {
                        Console.WriteLine(index.ToString() + ". " + it.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа Toy: " + counter);
            }
            else if (t == typeof(MilkProduct))
            {
                Console.WriteLine("Элементы типа MilkProduct: ");
                foreach (Item it in items)
                {
                    if (it != null && it is MilkProduct)
                    {
                        Console.WriteLine(index.ToString() + ". " + it.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа MilkProduct: " + counter);

            }
            if (counter == 0)
                Console.WriteLine("Такого типа нет в коллекции!\n");
            return;
        }

        //глубокая копия очереди
        public static Queue<Item> CopyQueue(Queue<Item> items)
        {

            Queue<Item> result = new Queue<Item>();
            foreach (Item it in items)
                result.Enqueue((Item)it.Clone());
            return result;
        }

        public static int FindItem(Queue<Item> items, Item item)
        {
            int index = -1;
            int counter = 0;
            foreach (Item p in items)
            {

                if (p.Equals(item))
                {
                    index = counter;
                    break;
                }
                counter += 1;
            }
            return index;
        }

        #endregion

        #region Работа со словарём

        public static Dictionary<Item, Product> GenerateDictionary()
        {
            Random rnd = new Random();
            int len = rnd.Next(4, 6);
            Dictionary<Item, Product> items = new Dictionary<Item, Product>();
            for (int i = 0; i < len; ++i)
            {
                try
                {
                    switch (rnd.Next(0, 3))
                    {
                        case 0:
                            Product employee = new Product();
                            items.Add(employee.BaseItem, employee);
                            break;
                        case 1:
                            MilkProduct engineer = new MilkProduct();
                            items.Add(engineer.BaseItem, engineer);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка генерации: " + ex.Message + "\n");
                    continue;
                }
            }
            return items;
        }
        //отображение словаря
        public static void DisplayDictionary(Dictionary<Item, Product> items)
        {
            if (items.Count != 0)
            {
                int counter = 0;
                foreach (var person in items)
                {
                    Console.Write($"{counter++}. Ключ: ");
                    Console.Write(person.Key);
                    Console.Write("\nЗначение: ");
                    Console.WriteLine(person.Value.ToString() + '\n');
                }
            }
            else
            {
                Console.WriteLine("Словарь пуст!\n");
            }
        }
        //отображение определённого типа из словаря
        public static void DisplayTypeInDictionary(Dictionary<Item, Product> items, Type t)
        {
            int counter = 0;
            int index = 0;
            if (t == typeof(Product))
            {
                Console.Write("Элементы типа Product:\n");
                foreach (var it in items)
                {
                    if (it.Value != null && (it.Value is Product) && !(it.Value is MilkProduct))
                    {
                        Console.WriteLine(index.ToString() + ". " + it.Value.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа Product: " + counter);
            }
            else if (t == typeof(MilkProduct))
            {
                Console.Write("Элементы типа MilkProduct:\n");
                foreach (var milk in items)
                {
                    if (milk.Value != null && (milk.Value is MilkProduct))
                    {
                        Console.WriteLine(index.ToString() + ". " + milk.Value.ToString());
                        ++counter;
                    }
                    ++index;
                }
                Console.WriteLine("Кол-во элементов типа MilkProduct: " + counter);
            }
            if (counter == 0)
                Console.Write("Такого типа нет в коллекции!\n");
            return;
        }
        //вставка случайного элемента в словарь
        public static void InsertRandomIntoDictionary(ref Dictionary<Item, Product> items)
        {
            Random rnd = new Random();
            try
            {
                switch (rnd.Next(0, 2))
                {
                    case 0:
                        Product product = new Product();
                        items.Add(product.BaseItem, product);
                        Console.Write($"Добавлен объект: {items[product.BaseItem]}\n");
                        break;
                    case 1:
                        MilkProduct milk = new MilkProduct();
                        items.Add(milk.BaseItem, milk);
                        Console.Write($"Добавлен объект: {items[milk.BaseItem]}\n");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Ошибка генерации: " + ex.Message + "\n");
            }
        }
        //удаление заданного элемента из словаря
        public static void DeleteItemFromDictionary(ref Dictionary<Item, Product> items)
        {
            Item key = Item.InputItem();
            if (items.Remove(key))
            {
                Console.Write($"Объект: {key}, успешно удалён!\n");
            }
            else
            {
                Console.Write("Такого ключа нет в словаре!\n");
            }
        }
        public static Dictionary<Item, Product> CopyDictionary(Dictionary<Item, Product> items)
        {
            var result = new Dictionary<Item, Product>();
            foreach (var pair in items)
            {
                result.Add((Item)pair.Key.Clone(), (Product)pair.Value.Clone());
            }
            return result;
        }



        #endregion

        static void Main(string[] args)
        {
            Menu.MainMenu();
        }
    }
}