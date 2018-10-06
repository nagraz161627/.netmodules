using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualOverrideDemo
{
    public class SalesPerson : Employee
    {
        int salesBonus;
        int noofSales;

        public int SalesBonus
        {
            get { return salesBonus; }
        }

        public int NumberofSales
        {
            get { return noofSales; }
        }

        public SalesPerson(int salary, int salesCount) : base(salary)
        {
            noofSales = salesCount;
        }

        public override int GiveBonus(int amount)
        {
            if (noofSales > 0 && noofSales <= 100)
                salesBonus = 10;
            else if (noofSales >= 101 && noofSales <= 300)
                salesBonus = 15;
            else
                salesBonus = 20;

            return base.GiveBonus(amount * salesBonus);
        }
    }
}
