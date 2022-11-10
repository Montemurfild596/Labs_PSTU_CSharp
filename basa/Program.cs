using System;

namespace basa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] {1, 2, 3, 4, 5};
            foreach (int temp in a)
            {
                Console.WriteLine(temp);
            }
            a = new int[3];
            foreach (int temp in a)
            {
                Console.WriteLine(temp);
            }
        }
    }
}






/* int n;
 * bool isConvect = Int.TryParse(buf, out n);
 * if (isConvert) { ... }
 * 
 * 
 * 
 * 
 * 
 */

/* Тестирование
 * 1 страница: Тест(фото)
 * 2 страница: Чёрный ящик(фото)
 * 3 страница: Белый ящик(фото)
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */