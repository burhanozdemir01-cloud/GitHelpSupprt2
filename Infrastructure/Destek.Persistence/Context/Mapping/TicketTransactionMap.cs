using Destek.Domain.Entities;
using Destek.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Destek.Persistence.Context.Mapping
{
    public class TicketTransactionMap : IEntityTypeConfiguration<TicketTransaction>
    {
        public void Configure(EntityTypeBuilder<TicketTransaction> builder)
        {
            builder.HasKey(x => x.Id);
   
            builder.Property(x => x.TicketId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(a => a.Description).HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.OperationType).IsRequired();
          

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
            builder.HasOne<Ticket>(a => a.Ticket).WithMany(c => c.TicketTransactions).HasForeignKey(a => a.TicketId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<AppUser>(x => x.AppUser).WithMany(c => c.TicketTransactions).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("TicketTransactions");
        }
    }
}
