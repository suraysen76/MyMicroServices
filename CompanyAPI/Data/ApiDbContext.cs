using Microsoft.EntityFrameworkCore;
using CompanyAPI.Models;


namespace CompanyAPI.Data
{
    public class ApiDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //use this to configure the context object
            //Configuring the Connection String
            optionsBuilder.UseSqlServer(@"Server=.;Database=CompaniesAPIDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyEmployees> CompanyEmployees { get; set; }
    }
}
