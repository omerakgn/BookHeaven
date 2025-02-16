using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHeaven.Repository.Configurations
{
    internal class BookConfigurations : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.Price).HasColumnType("decimal(19,2)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.StockCode).HasColumnType("nvarchar(20)");
            builder.Property(x => x.Manufacturer).HasColumnType("nvarchar(50)");

            builder.HasMany(b => b.Comments)  // Bir kitabın birden fazla yorumu olabilir
           .WithOne(c => c.Book)  // Her yorumun bir kitabı olmalı
           .HasForeignKey(c => c.BookId)  // Yorumda hangi kitabın referans alındığını belirtiyoruz
           .OnDelete(DeleteBehavior.Cascade);  // Kitap silindiğinde yorumlar da silinsin

            


            builder.ToTable("Books");

        }
    }
}
