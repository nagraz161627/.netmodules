using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleDimensionArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Enter the element : ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Array Elements : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }

            Array.Sort(arr);
            Console.WriteLine("\n\nSorted Array Elements Are : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }

            Array.Reverse(arr);
            Console.WriteLine("\n\nReverse Array Elements Are : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
            Console.ReadKey();
        }
    }
}
