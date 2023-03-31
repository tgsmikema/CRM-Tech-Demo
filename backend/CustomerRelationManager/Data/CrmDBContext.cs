using Microsoft.EntityFrameworkCore;
using CustomerRelationManager.Model;
using Task = CustomerRelationManager.Model.Task;

namespace CustomerRelationManager.Data
{
    public class CrmDBContext : DbContext
    {
        public CrmDBContext(DbContextOptions<CrmDBContext> options) : base(options) { }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
