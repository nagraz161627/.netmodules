using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size of Integer : " + sizeof(int));
            Console.WriteLine("Size of float : " + sizeof(float));
            Console.WriteLine("Size of Char : " + sizeof(char));
            Console.WriteLine("Size of Double : " + sizeof(double));
            Console.WriteLine("Size of Boolean : " + sizeof(Boolean));
            Console.WriteLine("Size of Byte : " + sizeof(byte));

            Console.WriteLine("Max Limit of Int : " + int.MaxValue);
            Console.WriteLine("Min Limit of Int : " + int.MinValue);

            Console.WriteLine("Type of int : " + typeof(int));

            //int num = 123;
            //Console.WriteLine("Type of 123 : " + num.GetType());

            int num = 123;
            object obj = num;
            int another = (int)obj;

            Console.ReadKey();
        }
    }
}
