using System;
using System.Data.Entity;

namespace DataAccessLayer.DbLayer
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name = EntityFramework")
        {
            Database.SetInitializer<CustomerContext>(
                new DropCreateDatabaseAlways<CustomerContext>()
            );
        }

        // objects from DB
        public DbSet<Customer> Customers { get; set; }
    }
}
