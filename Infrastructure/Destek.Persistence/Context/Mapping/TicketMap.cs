using Destek.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Context.Mapping
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
       
            builder.Property(x => x.SubCategoryId).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(300);

            builder.Property(x => x.Detail).IsRequired(false);
            builder.Property(a => a.Detail).HasColumnType("NVARCHAR(MAX)");

            builder.Property(x => x.TraceNumber).IsRequired().HasMaxLength(200); ;
            builder.Property(x => x.NormalizedTraceNumber).IsRequired().HasMaxLength(200);
            builder.HasIndex(x => x.NormalizedTraceNumber).HasDatabaseName("TraceNumberIndex").IsUnique();
            builder.Property(x => x.ImportanceLevel).IsRequired();
            builder.Property(x => x.IsNew).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsImportand).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.ModifiedByName).IsRequired();
            builder.Property(x => x.ModifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.Note).IsRequired(false);       
            builder.HasOne<SubCategory>(a => a.SubCategory).WithMany(c => c.Tickets).HasForeignKey(a => a.SubCategoryId).OnDelete(DeleteBehavior.Restrict);
           builder.HasOne<Department>(x => x.Department).WithMany(c => c.Tickets).HasForeignKey(a => a.DepartmentId).OnDelete(DeleteBehavior.Restrict); 
          
            builder.ToTable("Tickets");
        }
    }
}
