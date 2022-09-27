using ZAW.SalaryCalculationConsole.Domain;
using ZAW.SalaryCalculationConsole.Domain.Person;
using ZAW.SalaryCalculationConsole.Persistence;

internal class Program
{
    private static void Main(string[] args)
    {
        Manager manager = new Manager("John", new List<TimeRecord>() {
            new TimeRecord(DateTime.Now.AddDays(-1), "John1", 8, "message1"),
            new TimeRecord(DateTime.Now.AddDays(-2), "John2", 9, "message2"),
            new TimeRecord(DateTime.Now.AddDays(-3), "John3", 7, "message3")
        });
        Console.WriteLine(manager.TotalPay);
        Console.ReadLine();

    }
}