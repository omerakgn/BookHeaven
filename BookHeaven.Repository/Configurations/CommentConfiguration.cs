using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookHeaven.Repository.Configurations
{
    internal class CommentConfigurations : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Yorumun ID'si
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseIdentityColumn();

            // Yorum içerik kısmı ve kullanıcı adı
            builder.Property(c => c.Content)
                .IsRequired()
                .HasColumnType("nvarchar(1000)");  // Yorum metninin en fazla 1000 karakter olmasını sağlıyoruz

            builder.Property(c => c.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");  // Kullanıcı adı zorunlu ve 100 karakterle sınırlı

            // Foreign Key olarak BookId'yi tanımlıyoruz
            builder.HasOne(c => c.Book)  // Her yorum bir kitaba ait
                .WithMany(b => b.Comments)  // Bir kitap birden fazla yorum alabilir
                .HasForeignKey(c => c.BookId)  // Comment tablosunda BookId foreign key olacak
                .OnDelete(DeleteBehavior.Cascade);  // Kitap silindiğinde yorumlar da silinsin

            builder.Property(c => c.CreateDate)
                .HasColumnType("datetime");

            builder.Property(c => c.UpdateDate)
                .HasColumnType("datetime");

            builder.ToTable("Comments");
        }
    }

}
