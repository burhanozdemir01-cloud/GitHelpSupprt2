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
    public class WarehouseTransactionMap : IEntityTypeConfiguration<WarehouseTransaction>
    {
        public void Configure(EntityTypeBuilder<WarehouseTransaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.WarehouseId).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.TransactionType).IsRequired();

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
            

            builder.HasOne<Warehouse>(a => a.Warehouse).WithMany(c => c.WarehouseTransactions).HasForeignKey(a => a.WarehouseId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Product>(a => a.Product).WithMany(c => c.WarehouseTransactions).HasForeignKey(a => a.ProductId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Ticket>(a => a.Ticket).WithMany(c => c.WarehouseTransactions).HasForeignKey(a => a.TicketId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("WarehouseTransactions");
        }
    }
}
