using Employee.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.DbContexts
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Entities.Employee> Employees { get; set; } = null!;

        public EmployeeContext(DbContextOptions<EmployeeContext> options) 
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
