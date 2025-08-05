using Destek.Domain.Entities;
using Destek.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Context.Mapping
{
    public class TicketAssignMap : IEntityTypeConfiguration<TicketAssign>
    {
        public void Configure(EntityTypeBuilder<TicketAssign> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.TicketId).IsRequired();
            builder.Property(x => x.AppUserId).IsRequired();
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(500);

            builder.Property(x => x.JobCount).IsRequired();
            builder.Property(a => a.ExtraPoint).IsRequired();

            builder.Property(x => x.SendSms).IsRequired();
     
            builder.Property(x => x.JobStartDate).IsRequired(false);
            builder.Property(x => x.JobEndDate).IsRequired(false);
       

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
            builder.HasOne<Ticket>(a => a.Ticket).WithMany(c => c.TicketAssigns).HasForeignKey(a => a.TicketId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne<AppUser>(x => x.AppUser).WithMany(c => c.TicketAssigns).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("TicketAssigns");
        }
    }
}
