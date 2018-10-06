using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedLocalVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            //var val;    //Error : Implicitly Typed Local Variables must be initialized

            //var str = null; //Error : Cannot assign null to an Implicitly Typed Local Variable

            var str = "Capgemini";
            str = null;

            //var arr = { 1, 2, 3, 4, 5 }; //Error : Cannot initialize an Implicitly Type Local Variables with an Array Initializers

            var arr = new int[] { 1, 2, 3, 4, 5 };

            var num = 10.5;
            //num = false;

            float f = 34.76f;

            Console.ReadKey();
        }
    }
}
