using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    public class Freelancer : Person
    {
        public Freelancer(string name, List<TimeRecord> timeRecords) : base(name, timeRecords)
        {
        }
    }
}
