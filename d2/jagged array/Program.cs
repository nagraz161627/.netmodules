using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArrayDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] cities = new char[2][];

            for (int i = 0; i < cities.GetLength(0); i++)
            {
                int size;
                Console.Write("Enter the number of character for city " + i);
                size = Convert.ToInt32(Console.ReadLine());

                cities[i] = new char[size];
                Console.WriteLine("Enter the city characters : ");
                for (int j = 0; j < cities[i].Length; j++)
                {
                    cities[i][j] = Convert.ToChar(Console.ReadLine());
                }
            }

            Console.WriteLine("Cities Are : ");
            for (int i = 0; i < cities.GetLength(0); i++)
            {
                for (int j = 0; j < cities[i].Length; j++)
			    {
			        Console.Write(cities[i][j]);
			    }
                Console.WriteLine();
            }
			
            Console.ReadKey();
        }
    }
}
