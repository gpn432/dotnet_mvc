using Microsoft.EntityFrameworkCore;
using Demo8.Models.DB_Models;  // Add the corresponding Model of the table
using Demo8.Configurations.EmpConfig; //Add the corrsponding Configurations we want.

namespace Demo8.Data
{
    public class Demo8dbContext : DbContext
    {
        public Demo8dbContext(DbContextOptions<Demo8dbContext> options) : base(options) { }

        public DbSet<Emp> Emp_table { get; set; } // Add the table here. add more tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit configuration mapping
            modelBuilder.ApplyConfiguration(new EmpConfig());

            // If you add more tables later:
            // modelBuilder.ApplyConfiguration(new ProjectConfig());
            // modelBuilder.ApplyConfiguration(new SalaryConfig());
            // ...
        }
    }
}
