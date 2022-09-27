using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    public class Person
    {
        public string Name { get; }
        public  List<TimeRecord> TimeRecords { get; }

        public Person(string name, List<TimeRecord> timeRecords)
        {
            Name = name;
            TimeRecords = timeRecords;
        }

    }
}
