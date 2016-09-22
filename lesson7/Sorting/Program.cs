using System;
using System.Linq;
using System.Collections.Generic;
using DataLayer;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<EmployeeExt> empexts = DataManager.GetEmployeeExt();


            Console.WriteLine("\n\tBefore sorting");
            foreach (var item in empexts)
                Console.WriteLine(item);

            var query = from em in empexts
                        orderby em.LastName, em.HireDate descending
                        select em;

            Console.WriteLine("\n\tAfter sorting");
            foreach (var item in query)
                Console.WriteLine(item);

            var queryL = empexts.OrderBy(em => em.LastName)
                        .ThenByDescending(em => em.HireDate);

            Console.WriteLine("\n\tAfter sorting");
            foreach (var item in queryL)
                Console.WriteLine(item);

            string[] websites = { "vk.com", "youtube.com", "instagram.com", "eyeem.com", "greeflas.esy.es", "linkedin.com", "meta.ua" };

            var query2 = from w in websites
                         orderby w[w.LastIndexOf('.') + 1], w
                         select w;

            Console.WriteLine("\n\tWebsites");
            foreach (var item in query2)
                Console.WriteLine(item);

            var queryL2 = websites.OrderBy(site => site[site.LastIndexOf('.') + 1]).ThenBy(site => site);

            Console.WriteLine("\n\tWebsites Lambda");
            foreach (var item in queryL2)
                Console.WriteLine(item);

            Console.WriteLine();
        }
    }
}
