using System;
using System.Data.Entity.Migrations;
using DataAccessLayer;
using DataAccessLayer.DbLayer;

namespace _02_OneToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            UserContext context = new UserContext();

            User u1 = new User()
            {
                Id = 1,
                Login = "vasya123",
                Password = "qwerty1234567890"
            };

            User u2 = new User()
            {
                Id = 2,
                Login = "superPetro",
                Password = "123456q"
            };

            User u3 = new User()
            {
                Id = 3,
                Login = "Deman",
                Password = "sd5DGq124fj05"
            };

            Profile profile1 = new Profile()
            {
                Id = 1,
                User = u1,
                Name = "Vasya",
                Age = 17
            };

            Profile profile3 = new Profile()
            {
                Id = 3,
                User = u3,
                Name = "Vladimir",
                Age = 19
            };

            context.User.AddOrUpdate(u1);
            context.User.AddOrUpdate(u2);
            context.User.AddOrUpdate(u3);

            context.Profile.AddOrUpdate(profile1);
            context.Profile.AddOrUpdate(profile3);

            context.SaveChanges();

            Console.WriteLine("Successfully!");
        }
    }
}
