using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public class TestCollections
    {
        public const int MIN_LENGTH = 10;  //включительно
        public const int MAX_LENGTH = 1000;  //не включительно
        public Queue<Item> itemsQueue { get; set; }
        public Queue<string> stringQueue { get; set; }

        public Dictionary<Item, Product> itemsDict { get; set; }
        public Dictionary<string, Product> stringDict { get; set; }
        public TestCollections(int len)
        {
            itemsQueue = new Queue<Item>();
            stringQueue = new Queue<string>();
            itemsDict = new Dictionary<Item, Product>();
            stringDict = new Dictionary<string, Product>();
            for (int i = 0; i < len; ++i)
            {
                try
                {
                    Product product = new Product();
                    itemsDict.Add(product.BaseItem, product);
                }
                catch
                {
                    --i;
                    continue;
                }
            }
            foreach (var item in itemsDict)
            {
                itemsQueue.Enqueue(item.Key);
                stringQueue.Enqueue(item.Key.ToString());
                stringDict.Add(item.Key.ToString(), item.Value);
            }
        }
        public void Display()
        {
            Console.Write("Queue<Item>:\n");
            Program.DisplayQueue(itemsQueue);

            Console.Write("Dictionary<Item, Product>:\n");
            Program.DisplayDictionary(itemsDict);
        }
        public void RunTests()
        {
            if (itemsDict.Count != 0)
            {
                Product[] Products = new Product[itemsDict.Count];
                itemsDict.Values.CopyTo(Products, 0);

                Product product = Products[0];
                Console.Write($"Первый элемент коллекций: {product}\n");
                GetMeasurements(product);

                product = Products[Products.Length / 2];
                Console.Write($"Элемент из середины коллекций: {product}\n");
                GetMeasurements(product);

                product = Products[Products.Length - 1];
                Console.Write($"Элемент из конца коллекций: {product}\n");
                GetMeasurements(product);

                product = new Product(0, 0, 0);
                Console.Write($"Несуществующий элемент: \n");
                GetMeasurements(product);
            }
            else
            {
                Console.Write("Нельзя запустить тестирование для коллекций без элементов!\n");
            }
        }
        private void GetMeasurements(Product product)
        {
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            bool isFind;

            Item item = product.BaseItem;
            string itemStr = item.ToString();

            Console.Write("Объект найден в коллекции Queue<Item>: ");
            stopWatch.Start();
            isFind = itemsQueue.Contains(item);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден в коллекции Queue<string>: ");
            stopWatch.Start();
            isFind = stringQueue.Contains(itemStr);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по ключу в коллекции Dictionary<Item, Product>: ");
            stopWatch.Start();
            isFind = itemsDict.ContainsKey(item);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска:  [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по ключу в коллекции Dictionary<string, Product>: ");
            stopWatch.Start();
            isFind = stringDict.ContainsKey(itemStr);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();

            Console.Write("Объект найден по значению в коллекции Dictionary<Item, Product>: ");
            stopWatch.Start();
            isFind = stringDict.ContainsValue(product);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine(isFind.ToString() + ", время поиска: [" + ts.Ticks + "] такта");
            stopWatch.Reset();
        }
        public void AddRandom()
        {
            Product product = new Product();
            try
            {
                itemsDict.Add(product.BaseItem, product);
                stringQueue.Clear();
                itemsQueue.Clear();
                stringDict.Clear();
                foreach (var item in itemsDict)
                {
                    itemsQueue.Enqueue(item.Key);
                    stringQueue.Enqueue(item.Key.ToString());
                    stringDict.Add(item.Key.ToString(), item.Value);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Ошибка генерации: " + ex.Message + "\n");
            }
        }
        public void Delete()
        {
            Item key = Item.InputItem();
            if (itemsDict.Remove(key))
            {
                Console.Write($"Объект: {key}, успешно удалён!\n");
            }
            else
            {
                Console.Write("Такого ключа нет в словаре!\n");
            }
            stringQueue.Clear();
            itemsQueue.Clear();
            stringDict.Clear();
            foreach (var item in itemsDict)
            {
                itemsQueue.Enqueue(item.Key);
                stringQueue.Enqueue(item.Key.ToString());
                stringDict.Add(item.Key.ToString(), item.Value);
            }
        }
    }
}
