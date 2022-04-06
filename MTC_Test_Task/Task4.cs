using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
4.	Высший сорт.
Реализуйте метод Sort. Известно, что потребители метода зачастую не будут вычитывать данные до конца. 
Оптимально ли Ваше решение с точки зрения скорости выполнения? С точки зрения потребляемой памяти?
/// <summary>
/// Возвращает отсортированный по возрастанию поток чисел
/// </summary>
/// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
/// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. 
/// Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
/// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
/// <returns>Отсортированный по возрастанию поток чисел.</returns>
IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
*/

namespace MTC_Test_Task
{
    internal class Task4
    {
        internal static void Run()
        {

        }
        internal static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (sortFactor == 0) return inputStream;
            
            IEnumerable<int> result = null;

            int lastElement = inputStream.ElementAt(0);
            int dif = inputStream.ElementAt(0) - sortFactor;

            while (inputStream.ElementAt(0) - sortFactor < 0)

            for (int i = 1; i < inputStream.Count(); i++)
            {
                if(inputStream.ElementAt(i) <= lastElement)
                {
                    result.Append(inputStream.ElementAt(i));
                }
                else
                {
                    result.Append(lastElement);
                }
            }

            return result;
        }
    }
}
