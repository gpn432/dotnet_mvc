using Microsoft.EntityFrameworkCore;
using Demo10.Models.DB_Models.ActionPageModel;  // Add the corresponding Model of the table
using Demo10.Configurations.Book_Config; //Add the corrsponding Configurations we want.

namespace Demo10.Data
{
    public class Demo10_db_Context : DbContext
    {
        public Demo10_db_Context(DbContextOptions<Demo10_db_Context> options) : base(options) { }

        public DbSet<BookModel> Book_Table { get; set; } // Add the table here. add more tables Here<BookModel> is the class name of the model for the dataset. apply this to Book_Config file
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Explicit configuration mapping
            modelBuilder.ApplyConfiguration(new Book_Config()); // Book_Config is the name of the class in the config page where the config is stored

            // If you add more tables later:
            // modelBuilder.ApplyConfiguration(new ProjectConfig());
            // modelBuilder.ApplyConfiguration(new SalaryConfig());
            // ...
        }
    }
}