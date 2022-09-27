using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    internal class Emploee : Staff
    {
        public Emploee(string name, List<TimeRecord> timeRecords) : base(name, 160000, timeRecords)
        {
        }
    }
}
