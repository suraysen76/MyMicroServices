using Microsoft.EntityFrameworkCore;
using EmployeesAPI.Models;


namespace EmployeesAPI.Data
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the context object
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=EmployeesAPIDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employees { get; set; }

    }
}
