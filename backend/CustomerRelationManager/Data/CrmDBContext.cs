using Microsoft.EntityFrameworkCore;
using CustomerRelationManager.Model;

namespace CustomerRelationManager.Data
{
    public class CrmDBContext : DbContext
    {
        public CrmDBContext(DbContextOptions<CrmDBContext> options) : base(options) { }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
