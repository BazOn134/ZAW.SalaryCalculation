using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain
{
    public class TimeRecord
    {
        public DateTime Time { get; }
        public string Name { get; }
        public byte Hours { get; }
        public string Message { get; }

        public TimeRecord(DateTime time, string name, byte hours, string message)
        {
            Time = time;
            Name = name;
            Hours = hours;
            Message = message;
        }



    }
}
