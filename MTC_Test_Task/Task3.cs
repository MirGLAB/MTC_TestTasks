using System;
using System.Collections.Generic;
using System.Linq;

/*
3.	Мне только спросить!
Реализуйте метод по следующей сигнатуре:
/// <summary>
/// <para> Отсчитать несколько элементов с конца </para>
/// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
/// </summary> 
/// <typeparam name="T"></typeparam>
/// <param name="enumerable"></param>
/// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
/// <returns></returns>
public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)

Возможно ли реализовать такой метод выполняя перебор значений перечисления только 1 раз?
*/

namespace MTC_Test_Task
{
    internal static class Task3
    {
        internal static void Run()
        {
            int[] array = new int[] {1, 2, 3, 4};
            int tailLength = 2;
            var result = array.EnumerateFromTail(tailLength);

            Console.Write("new[] {");
            foreach (var value in array)
                Console.Write($"{value} ");
            Console.Write("}.EnumerateFromTail(" + tailLength +") = ");

            foreach (var value in result)
                Console.Write($"({value.item}, {value.tail}) ");
            Console.WriteLine("\n");
        }

        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            IEnumerable<(T, int?)> result = new List<(T, int?)>();

            for (int i = enumerable.Count() - 1; i >= 0; i--)
            {
                int? tail;
                if (tailLength - 1 < 0)
                    tail = null;
                else
                    tail = --tailLength;
                result = result.Append((enumerable.ElementAt(i), tail));
            }

            return result.Reverse();
        }
    }
}
