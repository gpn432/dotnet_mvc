using Microsoft.EntityFrameworkCore;
using Demo11.Models.DB_Models.Action;  // Add the corresponding Model of the table
using Demo11.Configurations.StudentConfig; //Add the corrsponding Configurations we want.

namespace Demo11.Data
{
    public class Demo11_db_Context : DbContext
    {
        public Demo11_db_Context(DbContextOptions<Demo11_db_Context> options) : base(options) { }

        public DbSet<StudentModel> Student_Table { get; set; } // Add the table here. add more tables <Emp> is the name of the model class. this will be used in the config page too
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit configuration mapping
            modelBuilder.ApplyConfiguration(new StudentConfig());

            // If you add more tables later:
            // modelBuilder.ApplyConfiguration(new ProjectConfig());
            // modelBuilder.ApplyConfiguration(new SalaryConfig());
            // ...
        }
    }
}