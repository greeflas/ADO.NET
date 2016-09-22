using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EmployeeExt
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string INN { get; set; }
        public string NameJobTitle { get; set; }
        public System.DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:d} {2} {3, -8} {4:d} {5}", EmployeeId, DateBirthday, FirstName, LastName, HireDate, Salary);
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime DateBirthday { get; set; }
        public string INN { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1:d} {2} {3}", EmployeeId, DateBirthday, FirstName, LastName);
        }
    }
    public class EmpPromotion
    {
        public int EmpPromotionId { get; set; }
        public int EmployeeId { get; set; }
        public int JobTitleId { get; set; }
        public System.DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string NameJobTitle { get; set; }
    }

}
