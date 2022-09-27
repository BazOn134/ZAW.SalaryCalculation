using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZAW.SalaryCalculationConsole.Domain;
using ZAW.SalaryCalculationConsole.Domain.Person;

namespace ZAW.SalaryCalculationConsole.Persistence
{
    internal class MemoryRepository : IRepository
    {
        #region FakeData
        List<TimeRecord> emploees = new List<TimeRecord>() {
            new TimeRecord(DateTime.Now.AddDays(-3),"Иванов",8,"Иванов1"),
            new TimeRecord(DateTime.Now.AddDays(-3),"Петров",8,"Петров1"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Иванов",10,"Иванов2"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Петров",5,"Петров2"),
        };
        
        List<TimeRecord> freelansers = new List<TimeRecord>() {
            new TimeRecord(DateTime.Now.AddDays(-3),"Бонд",6,"Бонд1"),
            new TimeRecord(DateTime.Now.AddDays(-3),"Смит",9,"Смит1"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Бонд",10,"Бонд2"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Смит",5,"Смит2"),
        };

        List<TimeRecord> managers = new List<TimeRecord>() {
            new TimeRecord(DateTime.Now.AddDays(-3),"Борк",11,"Борк1"),
            new TimeRecord(DateTime.Now.AddDays(-2),"Борк",4,"Борк2"),
        };
        
        List<User> users = new List<User>() 
        {
            new User("Бонд", UserRole.Freelanser),
            new User("Смит", UserRole.Freelanser),
            new User("Иванов", UserRole.Emploee),
            new User("Петров", UserRole.Emploee),
            new User("Борк", UserRole.Manager),
        };
        #endregion

        public List<TimeRecord> Emploees()
        {
            return emploees;
        }

        
        public List<TimeRecord> Freelansers()
        {
            return freelansers;
        }

        public List<TimeRecord> Managers()
        {
            return managers;
        }

        public List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            var records = new List<TimeRecord>();
            switch (userRole)
            {
                case UserRole.Manager:
                    records = Managers();
                    break;
                case UserRole.Emploee:
                    records = Emploees();
                    break;
                case UserRole.Freelanser:
                    records = Freelansers();
                    break;
                default:
                    throw new NotImplementedException("Новая роль");
            }

            if (from == null) from = DateTime.Now.AddYears(-100);
            if (to == null) to = DateTime.Now;
            
            return records.Where(x => from.Value > x.Date && x.Date <= to.Value).ToList();
        }

        public List<TimeRecord> ReportGetByUserp(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null)
        {
            return ReportGet(userRole, from, to).Where(x => x.Name == userName).ToList();
        }

        public void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord)
        {
            switch (userRole)
            {
                case UserRole.Manager:
                    managers.Add(timeRecord);
                    break;
                case UserRole.Emploee:
                    emploees.Add(timeRecord);
                    break;
                case UserRole.Freelanser:
                    freelansers.Add(timeRecord);
                    break;
                default:
                    throw new NotImplementedException("Новая роль");
            }
        }

        public bool UserCreate(UserRole userRole, string name)
        {
            var newUser = new User(name, userRole);
            var existsUser = UserGet(name);
            if (existsUser == null)
            {
                users.Add(newUser);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public User UserGet(string name)
        {
            return Users().FirstOrDefault(x => x.Name == name);
        }


        public List<User> Users()
        {
            return users;
        }
    }
}
