using Demo10.Models.DB_Models.ActionPageModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo10.Configurations.Book_Config
{
    public class Book_Config : IEntityTypeConfiguration<BookModel> //<BookModel> is the name of the model class name. this is taken from Config page
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("Book_Table");

            builder.HasKey(e => e.Book_Id);

            builder.Property(e => e.Book_Id)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Book_Name)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Isbn_Code)
                   .HasDefaultValue(0);

            builder.Property(e => e.Author)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");

            builder.Property(e => e.Type)
                   .HasMaxLength(60)
                   .HasDefaultValue("Unknown");
        }
    }
}