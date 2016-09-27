using System;
using System.Data.Entity;

namespace DataAccessLayer.DbLayer
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name = User")
        {
            Database.SetInitializer<UserContext>(
                new DropCreateDatabaseAlways<UserContext>()
            );
        }

        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
