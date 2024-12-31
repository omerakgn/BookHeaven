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
            builder.Property(x => x.Description).HasColumnType("nvarchar(500)");
            builder.Property(x => x.StockCode).HasColumnType("nvarchar(20)");
            builder.Property(x => x.Manufacturer).HasColumnType("nvarchar(50)");
            builder.ToTable("Books");
        }
    }
}
