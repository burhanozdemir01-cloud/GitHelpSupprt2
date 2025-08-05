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
    public class ControllerEndpointMap : IEntityTypeConfiguration<ControllerEndpoint>
    {
        public void Configure(EntityTypeBuilder<ControllerEndpoint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.ControllerMenuId).IsRequired();
        
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.ActionType).HasMaxLength(200);

            builder.Property(x => x.HttpType).IsRequired();
            builder.Property(x => x.HttpType).HasMaxLength(200);

            builder.Property(x => x.Definition).IsRequired();
            builder.Property(x => x.Definition).HasMaxLength(200);

            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(500);

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
            builder.ToTable("ControllerEndpoints");
        }
    }
}
