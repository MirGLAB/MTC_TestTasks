using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
5.	Слон из мухи.
Программа выводит на экран строку «Муха», а затем продолжает выполнять остальной код. 
Реализуйте метод TransformToElephant так, чтобы программа выводила на экран строку «Слон», 
а затем продолжала выполнять остальной код, не выводя перед этим на экран строку «Муха».
*/

namespace MTC_Test_Task
{
    internal class Task5
    {
        internal static void Run()
        {
            TransformToElephant();
            Console.WriteLine("Муха");
            //... custom application code
            Console.WriteLine("НЕ муха");
        }

        static void TransformToElephant()
        {
            //... write your code here
            Console.WriteLine("Слон");
            Console.SetOut(new CustomWriter());
        }

        class CustomWriter : StringWriter
        {
            TextWriter defaultTextWriter = Console.Out;
            public override void WriteLine(string? value)
            {
                Console.SetOut(defaultTextWriter);
            }
        }
    }
}
