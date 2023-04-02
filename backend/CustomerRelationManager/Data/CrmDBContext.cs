using Microsoft.EntityFrameworkCore;
using CustomerRelationManager.Model;

namespace CustomerRelationManager.Data
{
    // DB Context class as the middleware for receiving data from the SQL database or 
    // converting model objects into the DB format and save into the DB.
    public class CrmDBContext : DbContext
    {
        // constructor
        public CrmDBContext(DbContextOptions<CrmDBContext> options) : base(options) { }

        // define what model class is going to be used in the DB.
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
