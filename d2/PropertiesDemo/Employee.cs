﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesDemo
{
    public class Employee
    {
        int empid;
        public int EmployeeID
        {
            get { return empid; }
            set { empid = value; }
        }

        string name;
        public string EmployeeName
        {
            get { return name; }
            set { name = value; }
        }
        
        double sal;
        public double Salary
        {
            get { return sal; }
            set { sal = value; }
        }
    }
}
