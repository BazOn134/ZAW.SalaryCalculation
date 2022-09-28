using ZAW.SalaryCalculationConsole.Domain.Person;
using ZAW.SalaryCalculationConsole.Domain;

namespace ZAW.SalaryCalculationConsole.Test
{
    public class PersonTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ManagerTotalPay()
        {
            Manager manager = new Manager("John", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-1), "John1", 8, "message1"),
                new TimeRecord(DateTime.Now.AddDays(-2), "John2", 9, "message2"),
                new TimeRecord(DateTime.Now.AddDays(-3), "John3", 7, "message3")
            });
            Assert.IsTrue(manager.TotalPay == 29750);
        }


        [Test]
        public void ManagerTotalPay2()
        {
            Manager manager = new Manager("John", new List<TimeRecord>() {
                new TimeRecord(DateTime.Now.AddDays(-2), "John2", 9, "message2"),
            });
            Assert.IsTrue(manager.TotalPay == 11000);
        }
    }
}