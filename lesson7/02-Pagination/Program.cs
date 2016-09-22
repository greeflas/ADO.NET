using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;

namespace _02_Pagination
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeExt> empext = DataManager.GetEmployeeExt();

            var pages = empext.Skip(4).Take(4);

            foreach (var item in pages)
                Console.WriteLine(item);

            Console.WriteLine();
        }
    }
}
