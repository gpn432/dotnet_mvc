using Demo8.Models.DB_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo8.Configurations.EmpConfig
{
    public class EmpConfig : IEntityTypeConfiguration<Emp>
    {
        public void Configure(EntityTypeBuilder<Emp> builder)
        {
            builder.ToTable("Emp_table");

            builder.HasKey(e => e.Emp_Id);

            builder.Property(e => e.Emp_Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Emp_Name)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Emp_Gender)
                   .HasMaxLength(45)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Emp_Age)
                   .HasDefaultValue(0);

            builder.Property(e => e.Emp_Dept)
                   .HasMaxLength(45)
                   .HasDefaultValue("Unknown");
        }
    }
}
