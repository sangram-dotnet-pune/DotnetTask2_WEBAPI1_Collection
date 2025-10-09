using Microsoft.EntityFrameworkCore;

namespace DotnetTask2_WEBAPI1_Collection.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

      public   DbSet<Employee> Employees { get; set; }
    }
}
