using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    public class Manager : Staff
    {
        public static decimal MonthBonus => 20000;
        public decimal TotalPay { get; }
        public Manager(string name, List<TimeRecord> timeRecords) : base(name, 200000, timeRecords)
        {
            decimal payPerHours = MonthSallery / Settings.WORK_HOURS_IN_MONTH;
            decimal bonusPerDay = MonthBonus / Settings.WORK_HOURS_IN_MONTH * 8;
            decimal totalPay = 0;
            foreach (var timeRecord in timeRecords)
            {
                if (timeRecord.Hours <= 8)
                {
                    totalPay += timeRecord.Hours * payPerHours;
                }
                else
                {
                    totalPay += 8 * payPerHours + bonusPerDay;
                }
            }
            TotalPay = totalPay;
        }
    }
}
