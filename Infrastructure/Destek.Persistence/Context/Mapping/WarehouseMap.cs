using Destek.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destek.Persistence.Context.Mapping
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Location).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(500);


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
            builder.HasOne<Department>(a => a.Department).WithMany(c => c.Warehouses).HasForeignKey(a => a.DepartmentId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Warehouses");
        }
    }
}
