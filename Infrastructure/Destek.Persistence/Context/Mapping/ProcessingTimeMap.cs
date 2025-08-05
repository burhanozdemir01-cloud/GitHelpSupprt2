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
    public class ProcessingTimeMap : IEntityTypeConfiguration<ProcessingTime>
    {
        public void Configure(EntityTypeBuilder<ProcessingTime> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.SubCategoryId).IsRequired();
            builder.Property(x => x.Minute).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired(false);
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.Note).IsRequired(false);
            builder.HasOne<SubCategory>(a => a.SubCategory).WithMany(c => c.ProcessingTimes).HasForeignKey(a => a.SubCategoryId).OnDelete(DeleteBehavior.Cascade); 

            builder.ToTable("ProcessingTimes");
        }
    }
}
