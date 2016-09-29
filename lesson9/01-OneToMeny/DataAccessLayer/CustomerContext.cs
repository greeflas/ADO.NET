using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccessLayer
{
    public class Initialize : DropCreateDatabaseAlways<CustomerContext>
    {
        protected override void Seed(CustomerContext context)
        {
            // Customers
            Customer[] customers =
            {
                new Customer()
                {
                    FirstName = "Vasya",
                    LastName = "Pupkin",
                    Email = "vasya@gmail.com",
                    Birthday = new DateTime(1995, 12, 31)
                },
                new Customer()
                {
                    FirstName = "Masha",
                    LastName = "Dudkina",
                    Email = "mashka@gmail.com",
                    Birthday = new DateTime(1997, 8, 2)
                }
            };

            // Orders
            Order[] orders =
            {
                new Order()
                {
                    ProductName = "iPhone CE",
                    Description = "Cool device.",
                    PurchaseDate = DateTime.Now,
                    Quantity = 2000,
                    Customer = customers[0]
                },
                new Order()
                {
                    ProductName = "iPhone 7",
                    Description = "Cool device.",
                    PurchaseDate = DateTime.Now,
                    Quantity = 2500,
                    Customer = customers[1]
                },
                new Order()
                {
                    ProductName = "iPad Pro",
                    Description = "Cool device.",
                    PurchaseDate = DateTime.Now,
                    Quantity = 500,
                    Customer = customers[1]
                }
            };

            // add customers
            foreach(Customer c in customers)
                context.Customers.Add(c);
            // add orders
            foreach (Order o in orders)
                context.Orders.Add(o);

            base.Seed(context);
        }
    }

    public class CustomerContext : DbContext
    {  
        public CustomerContext() : base("name = EntityFramework")
        {
            if(!Database.Exists())
            {
                Database.SetInitializer<CustomerContext>(new Initialize());
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
