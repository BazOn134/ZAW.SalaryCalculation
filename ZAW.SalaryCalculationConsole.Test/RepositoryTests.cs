using ZAW.SalaryCalculationConsole.Domain.Person;
using ZAW.SalaryCalculationConsole.Domain;
using ZAW.SalaryCalculationConsole.Persistence;
using System.Reflection.Metadata;

namespace ZAW.SalaryCalculationConsole.Test
{
    public class RepositoryTests
    {
        IRepository repository = new MemoryRepository();
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UserCreateManager()
        {
            string userName = "Wiliams";
            bool isCreated = repository.UserCreate(UserRole.Manager, userName);
            var newUser = repository.Users().FirstOrDefault(x => x.Name == userName);

            Assert.IsTrue(isCreated);
            Assert.IsTrue(newUser.UserRole == UserRole.Manager);
            Assert.IsNotNull(newUser);
        }

        [Test]
        public void UserCreateManagerExisted()
        {
            string userName = "Иванов";
            bool isCreated = repository.UserCreate(UserRole.Manager, userName);
            var newUser = repository.Users().FirstOrDefault(x => x.Name == userName);

            Assert.IsTrue(!isCreated);
            Assert.IsTrue(newUser.UserRole != UserRole.Manager);
            Assert.IsNotNull(newUser);
        }
         
        
        [Test]
        public void UserGetTest()
        {
            string userName = "Иванов";
            var user = repository.UserGet(userName);
            userName = "Wili";
            var userWili = repository.UserGet(userName);

            Assert.IsNotNull(user);
            Assert.IsNull(userWili);
        }


        [Test]
        public void ReportGetByUserEmploeesTest()
        {
            var memoryList = repository.ReportGetByUser("Иванов", UserRole.Emploee);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"Иванов",8,"Иванов1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"Иванов",10,"Иванов2")
            };
            Assert.IsTrue(Enumerable.SequenceEqual(memoryList, sampleList, new TimeRecordComparer()));
        }

        [Test]
        public void ReportGetByUserManagerTest()
        {
            var memoryList = repository.ReportGetByUser("Борк", UserRole.Manager);
            var sampleList = new List<TimeRecord>()
            {
                new TimeRecord(DateTime.Now.Date.AddDays(-3),"Борк",11,"Борк1"),
                new TimeRecord(DateTime.Now.Date.AddDays(-2),"Борк",4,"Борк2")
            };

            Assert.IsTrue(Enumerable.SequenceEqual(memoryList, sampleList, new TimeRecordComparer()));
        }
   }
}