using Destek.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Context.Mapping
{
    public class CommonFileMap : IEntityTypeConfiguration<CommonFile>
    {
        public void Configure(EntityTypeBuilder<CommonFile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileName).HasMaxLength(300);
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Path).HasMaxLength(300);
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.Note).IsRequired(false);

            // builder.HasMany<Article>().WithOne().HasForeignKey(rc => rc.DilId).IsRequired();
            builder.ToTable("CommonFiles");
        }
    }
}
