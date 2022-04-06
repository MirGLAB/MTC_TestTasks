using System;

using System.Globalization;


/*
2.	Операция «Ы».
Что выводится на экран? Измените класс Number так, чтобы на экран выводился результат сложения 
для любых значений someValue1 и someValue2.
*/

namespace MTC_Test_Task
{
    internal class Task2
    {
		static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

		class Number
		{
			readonly int _number;

			public Number(int number)
			{
				_number = number;
			}

			public override string ToString()
			{
				return _number.ToString(_ifp);
			}

			public int GetInt()
            {
				return _number;
            }

			public static string operator +(Number number, string stringNumber)
            {
				string result = "";
				int value1 = number.GetInt();
				int value2;

				if (int.TryParse(stringNumber, out value2))
                {
					result = (value1 + value2).ToString();
                }
				else
                {
					Console.WriteLine("Error: value2");
                }
				
				return result;
            }
		}

		internal static void Run()
		{
			int someValue1 = 10;
			int someValue2 = 5;

			string result = new Number(someValue1) + someValue2.ToString(_ifp);
			Console.WriteLine($"{result}\n");
		}
	}
}
