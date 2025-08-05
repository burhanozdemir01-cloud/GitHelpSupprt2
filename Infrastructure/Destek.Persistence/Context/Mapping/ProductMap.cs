using Destek.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destek.Persistence.Context.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.WarehouseCategoryId).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Barcode)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(x => x.SerialNumber)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(x => x.UnitOfMeasureType).IsRequired();
             //.HasConversion(
             //   v => v.ToString(),
             //   v => (UnitOfMeasure)Enum.Parse(typeof(UnitOfMeasure), v));
            builder.Property(x => x.UnitsInStock)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); 

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.ModifiedByName)
                .IsRequired()
                .HasMaxLength(50);
          
            builder.Property(x => x.CreatedByName)
                .IsRequired()
                .HasMaxLength(50);
           
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Note)
                .IsRequired(false)
                .HasMaxLength(500);
       


            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.SerialNumber)
                .HasDatabaseName("SerialNumberIndex")
                .IsUnique();
     


            builder.HasOne<WarehouseCategory>(a => a.WarehouseCategory).WithMany(c => c.Products).HasForeignKey(a => a.WarehouseCategoryId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Brand>(a => a.Brand).WithMany(c => c.Products).HasForeignKey(a => a.BrandId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Products");
        }
    }
}
