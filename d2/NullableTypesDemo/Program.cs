using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num = null; 
            //Nullable<int> num = 123;

            int? num = null;

            if (num.HasValue)
                Console.WriteLine("Number is : " + num.Value);
            else
                Console.WriteLine("Number is NULL");

            Console.ReadKey();
        }
    }
}
