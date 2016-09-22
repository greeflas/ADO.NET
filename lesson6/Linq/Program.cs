using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Linq
{
    class Program
    {
        public static object BinaryFormat { get; private set; }

        static IEnumerable<int> GetYield()
        {
            Random r = new Random();
            for (int i = 0; i < 3; i++)
                yield return r.Next(0, 10);
        }

        static void Main(string[] args)
        {
            string[] cars = { "Mercedez", "Aston Martin", "BMW", "Ford", "Audi" };

            /* Lambda */
            var query = cars.Where(car => car.Length == 4);
            foreach (var item in query)
                Console.WriteLine(item);

            /* Classic */
            var query2 = from car in cars
                         where car.Length == 4
                         select car;
            foreach (var item in query2)
                Console.WriteLine(item);

            Console.WriteLine("\tTwo 'o' letters");
            var query3 = cars.Where(car => car.ToLower().Count(x => x == 'a') == 2);
            foreach (var item in query3)
                Console.WriteLine(item);

            Console.WriteLine("\n\tAnonym object");
            var query4 = cars.Where(car => car.Length < 5)
                        .Select(car => new { car, car.Length });
            foreach (var item in query4)
                Console.WriteLine(item);

            Console.WriteLine("\n\tEnumerable");
            IEnumerable<int> res = GetYield();
            foreach (var item in res)
                Console.WriteLine(item + ' ');

        }
    }
}
