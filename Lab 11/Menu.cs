using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_11
{
    public class Menu
    {
        public static void MainMenu()
        {
            bool needExit = false;
            Queue<Item> itemsQueue = Program.GenerateQueue();
            Dictionary<Item, Product> ItemsDict = Program.GenerateDictionary();
            TestCollections testCollections = new TestCollections(TestCollections.MIN_LENGTH);

            while (!needExit)
            {
                Console.Write("1. 1 часть\n2. 2 часть\n3. 3 часть\n0. Назад\n");
                int command = Input.TypeInteger("Введите команду: ");
                switch (command)
                {
                    case 1:
                        FirstPart(ref itemsQueue);
                        break;
                    case 2:
                        SecondPart(ref ItemsDict);
                        break;
                    case 3:
                        ThirdPart(ref testCollections);
                        break;
                    case 0:
                        needExit = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная функция");
                        break;
                }
            }
        }

        public static void FirstPart(ref Queue<Item> itemsQueue)
        {
            bool needExit = false;
            while (!needExit)
            {
                Console.Write("\n1. Генерация и вывод новой очереди\n" +
                   "2. Добавить объект в очередь (объект добавиться в конец)\n" +
                   "3. Удалить объект из очереди (удалится первый объект)\n" +
                   "4. Вывести все элементы типа Item и их количество\n" +
                   "5. Вывести все элементы типа Product и их количество\n" +
                   "6. Вывести все элементы типа MilkProduct и их количество\n" +
                   "7. Выполнить клонирование коллекции\n" +
                   "8. Выполнить сортировку коллекции\n" +
                   "9. Выполнить поиск элемента в коллекции\n" +
                   "0. Назад\n");
                Console.Write("Исходная очередь:\n");
                Program.DisplayQueue(itemsQueue);
                int command = Input.TypeIntBetween(0, 10, "Введите команду: ");
                switch (command)
                {
                    case 1:
                        itemsQueue = Program.GenerateQueue();
                        Program.DisplayQueue(itemsQueue);
                        break;
                    case 2:
                        itemsQueue.Enqueue(Item.InputItem());
                        break;
                    case 3:
                        if (itemsQueue.Count != 0)
                            Console.Write($"Из начала очереди удалён объект: {itemsQueue.Dequeue()}!\n");
                        else
                            Console.Write("Удаление из пустой очереди невозможно!\n");
                        break;
                    case 4:
                        Program.DisplayTypeInQueue(itemsQueue, typeof(Item));
                        break;
                    case 5:
                        Program.DisplayTypeInQueue(itemsQueue, typeof(Product));
                        break;
                    case 6:
                        Program.DisplayTypeInQueue(itemsQueue, typeof(MilkProduct));
                        break;
                    case 7:
                        Queue<Item> itemsQueueCopy = Program.CopyQueue(itemsQueue);
                        int len = itemsQueue.Count;
                        for (int i = 0; i < len; ++i)
                            Console.Write($"Из начала исходной очереди удалён объект: {itemsQueue.Dequeue()}!\n");
                        Console.Write("Исходная очередь:\n");
                        Program.DisplayQueue(itemsQueue);
                        Console.Write("Копия очереди:\n");
                        Program.DisplayQueue(itemsQueueCopy);
                        itemsQueue = Program.CopyQueue(itemsQueueCopy);
                        break;
                    case 8:
                        Program.SortQueue(ref itemsQueue);
                        Console.Write("Очередь успешно отсортирована!\n");
                        break;
                    case 9:
                        Console.WriteLine($"Индекс элемента в очереди: {Program.FindItem(itemsQueue, Item.InputItem())}");
                        break;
                    case 0:
                        needExit = true;
                        break;
                }
            }

        }
        public static void SecondPart(ref Dictionary<Item, Product> ItemsDict)
        {
            bool needExit = false;
            while (!needExit)
            {
                Console.Write("\n1. Генерация и вывод нового словаря\n" +
                   "2. Добавить объект в словарь\n" +
                   "3. Удалить объект из словаря\n" +
                   "4. Вывести все элементы типа Product и их количество\n" +
                   "5. Вывести все элементы типа MilkProduct и их количество\n" +
                   "6. Выполнить клонирование коллекции\n" +
                   "7. Выполнить поиск элемента в коллекции\n" +
                   "0. Назад\n");
                Console.Write("Исходный словарь:\n");
                Program.DisplayDictionary(ItemsDict);
                int command = Input.TypeIntBetween(0, 8, "Введите команду: ");
                switch (command)
                {
                    case 1:
                        ItemsDict = Program.GenerateDictionary();
                        break;
                    case 2:
                        Program.InsertRandomIntoDictionary(ref ItemsDict);
                        break;
                    case 3:
                        Program.DeleteItemFromDictionary(ref ItemsDict);
                        break;
                    case 4:
                        Program.DisplayTypeInDictionary(ItemsDict, typeof(Product));
                        break;
                    case 5:
                        Program.DisplayTypeInDictionary(ItemsDict, typeof(MilkProduct));
                        break;
                    case 6:
                        var ItemsDictCopy = Program.CopyDictionary(ItemsDict);
                        ItemsDict.Clear();
                        Console.Write("Исходный словарь:\n");
                        Program.DisplayDictionary(ItemsDict);
                        Console.Write("Копия словаря:\n");
                        Program.DisplayDictionary(ItemsDictCopy);
                        ItemsDict = Program.CopyDictionary(ItemsDictCopy);
                        break;
                    case 7:
                        try
                        {
                            Console.Write($"Объект {ItemsDict[Item.InputItem()]} содержтися в словаре!\n");
                        }
                        catch (Exception ex)
                        {
                            Console.Write($"{ex.Message}\n");
                        }
                        break;
                    case 0:
                        needExit = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная функция");
                        break;
                }
            }
        }
        public static void ThirdPart(ref TestCollections testCollections)
        {
            bool needExit = false;
            while (!needExit)
            {
                Console.Write("\n1. Генерация и вывод нового объекта TestCollections\n" +
                   "2. Добавить элемент в TestCollections\n" +
                   "3. Удалить объект из TestCollections\n" +
                   "4. Запустить тесты\n" +
                   "0. Назад\n");
                Console.Write("Исходный объект TestCollections:\n");
                testCollections.Display();
                int command = Input.TypeInteger("Введите команду: ");
                switch (command)
                {
                    case 1:
                        int size = Input.TypeIntBetween(10, 1000, $"Введите размер коллекции в отрезке [{10}, {1000}]");
                        testCollections = new TestCollections(size);
                        break;
                    case 2:
                        testCollections.AddRandom();
                        break;
                    case 3:
                        testCollections.Delete();
                        break;
                    case 4:
                        testCollections.RunTests();
                        break;
                    case 0:
                        needExit = true;
                        break;
                }
            }
        }
    }
}
