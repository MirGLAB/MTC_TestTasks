using System;
using System.Collections.Generic;
using System.Linq;

/*
1.Ломай меня полностью.
Реализуйте метод FailProcess так, чтобы процесс завершался.Предложите побольше различных решений.
*/

namespace MTC_Test_Task
{
    internal static class Task1
    {
		static int errorCase = 0;

		static internal void Run()
		{
			try
			{
				errorCase++;
				FailProcess();
			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			catch (InvalidCastException ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error case {errorCase}: {ex.Message}");
			}
			finally
			{
				if(errorCase <= 7)
					Run();
				else
					Console.WriteLine("Everything was successfully failed!\n");
				/*
				Console.WriteLine("Failed to fail process!");
				Console.ReadKey();
				*/
			}
		}

		static void FailProcess()
		{
			//... write your code here 
			switch (errorCase)
            {
				case 0:
					int zero = 0;
					int a = 12 / zero;
					break;
				case 1:
					List<int> list = new List<int>();
					list.ElementAt(0);
					break;
				case 2:
					throw new ArgumentException();
					break;
				case 3:
					int[] array = new int[] { 1, 2, 3, 4 };
					array[4] = 0;
					break;
				case 4:
					object errorObject = true;
					string errorString = (string) errorObject;
					break;
				case 5:
					throw new Exception("Another exception");
					break;
				default:
					break;
			}
		}
	}
}

