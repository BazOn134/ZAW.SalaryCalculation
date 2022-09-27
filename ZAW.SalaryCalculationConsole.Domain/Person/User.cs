using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.SalaryCalculationConsole.Domain.Person
{
    public class User
    {
        public User(string name, UserRole userRole)
        {
            Name = name;
            UserRole = userRole;
        }

        public string Name { get; }
        public UserRole UserRole { get; }
    }
}
