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
            List<int> inputStream = new List<int>();
			IEnumerable<int> outputStream;
            int sortFactor = 2000;
            int maxValue = 2000;
            int length = 1000000000;

			Random rnd = new Random();
			inputStream.Add(rnd.Next(0, maxValue + 1));
			var prevValue = inputStream.ElementAt(0);
			for (int i = 1; i < length; i++)
			{
				var dif = prevValue - sortFactor;
				dif = dif < 0 ? 0 : dif;
				var curValue = rnd.Next(dif, maxValue + 1);
				inputStream.Add(curValue);
				prevValue = curValue;
			}

			outputStream = Sort(inputStream, sortFactor, maxValue);

			Console.WriteLine("Stream was successfuly sorted!\n");
        }

		internal static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
			List<int> listInputStream = inputStream.ToList();

			int partitionSize = Partition(ref listInputStream, 0, listInputStream.Count() - 1);

			if (partitionSize < 16)
			{
				InsertionSort(ref listInputStream);
			}
			else if (partitionSize > (2 * Math.Log(listInputStream.Count())))
			{
				HeapSort(ref listInputStream);
			}
			else
			{
				QuickSortRecursive(ref listInputStream, 0, listInputStream.Count() - 1);
			}

			IEnumerable<int> result = listInputStream;
			return result;
		}

		private static void InsertionSort(ref List<int> listInputStream)
		{
			for (int i = 1; i < listInputStream.Count(); i++)
			{
				int value = listInputStream[i];
				int flag = 0;
				for (int j = i - 1; j >= 0 && flag != 1;)
				{
					if (value < listInputStream[j])
					{
						listInputStream[j + 1] = listInputStream[j];
						j--;
						listInputStream[j + 1] = value;
					}
					else
						flag = 1;
				}
			}
		}

		private static void HeapSort(ref List<int> listInputStream)
		{
			int heapSize = listInputStream.Count();
			int temp;

			for (int p = (heapSize - 1) / 2; p >= 0; --p)
				MaxHeapify(ref listInputStream, heapSize, p);

			for (int i = listInputStream.Count() - 1; i > 0; --i)
			{
				temp = listInputStream[i];
				listInputStream[i] = listInputStream[0];
				listInputStream[0] = temp;
				--heapSize;
				MaxHeapify(ref listInputStream, heapSize, 0);
			}
		}

		private static void MaxHeapify(ref List<int> listInputStream, int heapSize, int index)
		{
			int left = (index + 1) * 2 - 1;
			int right = (index + 1) * 2;
			int largest = 0;

			if (left < heapSize && listInputStream[left] > listInputStream[index])
				largest = left;
			else
				largest = index;

			if (right < heapSize && listInputStream[right] > listInputStream[largest])
				largest = right;

			if (largest != index)
			{
				int temp = listInputStream[index];
				listInputStream[index] = listInputStream[largest];
				listInputStream[largest] = temp;
				MaxHeapify(ref listInputStream, heapSize, largest);
			}
		}

		private static void QuickSortRecursive(ref List<int> listInputStream, int left, int right)
		{
			if (left < right)
			{
				int q = Partition(ref listInputStream, left, right);
				QuickSortRecursive(ref listInputStream, left, q - 1);
				QuickSortRecursive(ref listInputStream, q + 1, right);
			}
		}

		private static int Partition(ref List<int> listInputStream, int left, int right)
		{
			int pivot = listInputStream[right];
			int temp;
			int i = left;

			for (int j = left; j < right; ++j)
			{
				if (listInputStream[j] <= pivot)
				{
					temp = listInputStream[j];
					listInputStream[j] = listInputStream[i];
					listInputStream[i] = temp;
					i++;
				}
			}

			listInputStream[right] = listInputStream[i];
			listInputStream[i] = pivot;

			return i;
		}
	}
}