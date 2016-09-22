using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class DataManager
    {
        public static List<EmployeeExt> GetEmployeeExt()
        {
            List<EmployeeExt> list = new List<EmployeeExt>()
            {
                new EmployeeExt() { EmployeeId = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1958,8,15), INN="111111111", NameJobTitle = "Engineer", HireDate = new DateTime(2000,7,1), Salary=2000},
                new EmployeeExt() { EmployeeId = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1958,8,15), INN="111111111", NameJobTitle = "Programmer", HireDate = new DateTime(2007,12,16), Salary=3000},
                new EmployeeExt() { EmployeeId = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1958,8,15), INN="111111111", NameJobTitle = "Senjor programmer", HireDate = new DateTime(2009,10,21), Salary=7000},
                new EmployeeExt() { EmployeeId = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1958,8,15), INN="111111111", NameJobTitle = "Director", HireDate = new DateTime(2013,9,12), Salary=6500},
                new EmployeeExt() { EmployeeId = 2,  FirstName = "Ivan", LastName = "Darada",  DateBirthday = new DateTime(1980,4,22), INN="222222222", NameJobTitle = "Engineer", HireDate = new DateTime(2000,10,21), Salary=7500},
                new EmployeeExt() { EmployeeId = 3,  FirstName = "Petr", LastName = "Sivoy",  DateBirthday = new DateTime(1989,3,17), INN="333333333", NameJobTitle = "Programmer", HireDate = new DateTime(2010,10,21), Salary=6500},
                new EmployeeExt() { EmployeeId = 3,  FirstName = "Petr", LastName = "Sivoy",  DateBirthday = new DateTime(1989,3,17), INN="333333333", NameJobTitle = "Senjor programmer", HireDate = new DateTime(2012,7,22), Salary=3200},
                new EmployeeExt() { EmployeeId = 4,  FirstName = "Dasha", LastName = "Sejneko",  DateBirthday = new DateTime(1991,2,21), INN="777777777", NameJobTitle = "Programmer", HireDate = new DateTime(2014,5,13), Salary=3800},
                new EmployeeExt() { EmployeeId = 6,  FirstName = "Semen", LastName = "Rakov",  DateBirthday = new DateTime(1998,2,21), INN="999999999", NameJobTitle = "Manager", HireDate = new DateTime(2012,10,21), Salary=4500}
            };
            return list;
        }
        public static List<Employee> GetEmployee()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee() { EmployeeId = 1,  FirstName = "Igor", LastName = "Krivonos",  DateBirthday = new DateTime(1958,8,15), INN="111111111"},
                new Employee() { EmployeeId = 2,  FirstName = "Ivan", LastName = "darda",  DateBirthday = new DateTime(1980,4,22), INN="222222222"},
                new Employee() { EmployeeId = 3,  FirstName = "Petr", LastName = "Sivoy",  DateBirthday = new DateTime(1989,3,17), INN="333333333"},
                new Employee() { EmployeeId = 4,  FirstName = "Dasha", LastName = "Sejneko",  DateBirthday = new DateTime(1991,2,21), INN="777777777"},
                new Employee() { EmployeeId = 6,  FirstName = "Semen", LastName = "Rakov",  DateBirthday = new DateTime(1998,2,21), INN="999999999"}
            };
            return list;
        }


        public static List<EmpPromotion> GetEmpPromotion()
        {
            List<EmpPromotion> list = new List<EmpPromotion>()
            {
                new EmpPromotion() { EmpPromotionId=1,  EmployeeId=1, JobTitleId=2, HireDate = new DateTime(2000,7,1), Salary=2000},
                new EmpPromotion() { EmpPromotionId=2,  EmployeeId=1, JobTitleId=4, HireDate = new DateTime(2007,12,16), Salary=3000},
                new EmpPromotion() { EmpPromotionId=3,  EmployeeId=1, JobTitleId=6, HireDate = new DateTime(2009,10,21), Salary=7000},
                new EmpPromotion() { EmpPromotionId=4,  EmployeeId=1, JobTitleId=1, HireDate = new DateTime(2013,9,12), Salary=6500},

                new EmpPromotion() { EmpPromotionId=5,  EmployeeId=2, JobTitleId=6, HireDate = new DateTime(2000,10,21), Salary=7500},
                new EmpPromotion() { EmpPromotionId=6,  EmployeeId=3, JobTitleId=4, HireDate = new DateTime(2010,10,21), Salary=6500},

                new EmpPromotion() { EmpPromotionId=7,  EmployeeId=3, JobTitleId=5, HireDate = new DateTime(2011,10,21), Salary=4500},
                new EmpPromotion() { EmpPromotionId=8,  EmployeeId=4, JobTitleId=2, HireDate = new DateTime(2012,7,22), Salary=3200},
                new EmpPromotion() { EmpPromotionId=9,  EmployeeId=4, JobTitleId=3, HireDate = new DateTime(2014,5,13), Salary=3800},

                new EmpPromotion() { EmpPromotionId=10,  EmployeeId=7, JobTitleId=5, HireDate = new DateTime(2012,10,21), Salary=4500}

            };
            return list;
        }
        public static List<JobTitle> GetJobTitle()
        {
            List<JobTitle> list = new List<JobTitle>()
            {
                new JobTitle() {  JobTitleId = 1, NameJobTitle = "Director"},
                new JobTitle() {  JobTitleId = 2, NameJobTitle = "Engineer"},
                new JobTitle() {  JobTitleId = 3, NameJobTitle = "Senjor engineer"},
                new JobTitle() {  JobTitleId = 4, NameJobTitle = "Pogrammer"},
                new JobTitle() {  JobTitleId = 5, NameJobTitle = "Middle programmer"},
                new JobTitle() {  JobTitleId = 6, NameJobTitle = "Senjor programmer"},
                new JobTitle() {  JobTitleId = 7, NameJobTitle = "Manager"},
                new JobTitle() {  JobTitleId = 8, NameJobTitle = "Завхоз"}
            };
            return list;
        }
    }
}
