using System;
using System.Linq;

namespace Linq
{
    class Program
    {
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
        }
    }
}
