using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID : ");
            emp.EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            emp.EmployeeName = Console.ReadLine();
            Console.Write("Enter Salary : ");
            emp.Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Employee ID : " + emp.EmployeeID);
            Console.WriteLine("Employee Name : " + emp.EmployeeName);
            Console.WriteLine("Salary : " + emp.Salary);

            Console.ReadKey();
        }
    }
}
