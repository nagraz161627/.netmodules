using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate cal = new Calculate();

            int num1 = 30;
            int num2 = 10;

            int sub = cal.Subtract(num1, num2);
            int div = cal.Divide(num1, num2);
            int sum = Calculate.Add(num1, num2);
            int mult = Calculate.Multiply(num1, num2);

            Console.WriteLine("{0} + {1} => {2}", num1, num2, sum);
            Console.WriteLine("{0} - {1} => {2}", num1, num2, sub);
            Console.WriteLine("{0} * {1} => {2}", num1, num2, mult);
            Console.WriteLine("{0} / {1} => {2}", num1, num2, div);

            Console.ReadKey();
        }
    }
}
