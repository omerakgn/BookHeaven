using BookHeaven.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Repository.Configurations
{
    public class GroupConfigurations : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.ToTable("Groups");
        }
    }
}
