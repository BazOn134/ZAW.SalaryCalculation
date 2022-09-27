using ZAW.SalaryCalculationConsole.Domain;
using ZAW.SalaryCalculationConsole.Domain.Person;

namespace ZAW.SalaryCalculationConsole.Persistence
{
    public interface IRepository
    {
        List<User> Users();
        List<TimeRecord> Emploees();
        List<TimeRecord> Managers();
        List<TimeRecord> Freelansers();
        
        /// <summary>Создание пользователя</summary>
        /// <param name="Роль пользователя"></param>
        /// <param name="Имя пользователя"></param>
        bool UserCreate(UserRole userRole, string name);
        
        /// <summary>Получение пользователя</summary>
        /// <param name="Имя пользователя"></param>
        /// <returns></returns>
        User UserGet(string name);
        
        void TimeRecordAdd(UserRole userRole, TimeRecord timeRecord);
        
        /// <summary>Получение количества рабочих часов всех пользователь определенной роли за выбранный период</summary>
        /// <param name="Роль пользователя"></param>
        /// <param name="Дата начала периода"></param>
        /// <param name="Дата окончания периода"></param>
        /// <returns></returns>
        List<TimeRecord> ReportGet(UserRole userRole, DateTime? from = null, DateTime? to = null );
        
        /// <summary>Получение количества рабочих часов конкретного пользователя определенной роли за выбранный период</summary>
        /// <param name="Имя пользователя"></param>
        /// <param name="Роль пользователя"></param>
        /// <param name="Дата начала периода"></param>
        /// <param name="Дата окончания периода"></param>
        /// <returns></returns>
        List<TimeRecord> ReportGetByUserp(string userName, UserRole userRole, DateTime? from = null, DateTime? to = null);
    }
}