using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookHeaven.Repository.Configurations
{
    public class CategoriConfigurations : IEntityTypeConfiguration<Categori>
    {
        public void Configure(EntityTypeBuilder<Categori> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.ToTable("Categories");
        }
    }
}
