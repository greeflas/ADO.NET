using System;
using System.Data.Entity.Migrations;
using DataAccessLayer.DbLayer;

namespace _01_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerContext context = new CustomerContext();

            Customer customer = new Customer()
            {
                CustomerId = 0,
                FirstName = "Vasya",
                LastName = "Pupkin",
                Email = "pupkin@gmail.com",
                Birthday = new DateTime(1995, 12, 31)
            };

            Customer customer2 = new Customer()
            {
                CustomerId = 0,
                FirstName = "Semen",
                LastName = "Farada",
                Email = "semen@gmail.com",
                Birthday = new DateTime(1997, 5, 30)
            };

            context.Customers.AddOrUpdate(customer);
            context.Customers.AddOrUpdate(customer2);
            context.SaveChanges();

            Console.WriteLine("Successfully!");
        }
    }
}
