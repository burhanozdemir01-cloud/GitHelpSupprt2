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
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });
            //b.Property(x => x.Not).HasMaxLength(100);
            //b.Property(x => x.Not).IsRequired(false);
            //b.HasKey(x => x.Id);
            //b.Property(x => x.Id).ValueGeneratedOnAdd();
            // Maps to the AspNetUserRoles table
            builder.ToTable("AppUserRoles");
        }
    }
}
