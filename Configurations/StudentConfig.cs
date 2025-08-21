using Demo11.Models.DB_Models.Action;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo11.Configurations.StudentConfig
{
    public class StudentConfig : IEntityTypeConfiguration<StudentModel>
    {
        public void Configure(EntityTypeBuilder<StudentModel> builder)
        {
            builder.ToTable("Student_Table");

            builder.HasKey(e => e.Student_Id);

            builder.Property(e => e.Student_Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Student_Name)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Class)
                   .HasDefaultValue(0);

            builder.Property(e => e.Div)
                   .HasMaxLength(45)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Roll_No)
                   .HasDefaultValue(0);
            
            builder.Property(e => e.Age)
                   .HasDefaultValue(0);
        }
    }
}