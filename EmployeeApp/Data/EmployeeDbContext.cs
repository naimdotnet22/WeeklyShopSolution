using Microsoft.EntityFrameworkCore;
using zModelEntities.Models.EmployeeModels;

namespace EmployeeApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
