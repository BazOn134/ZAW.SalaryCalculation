using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    public class Staff : Person
    {
        public decimal MonthSallery { get; }

        public Staff(string name) : base(name)
        {
        }
    }
}
