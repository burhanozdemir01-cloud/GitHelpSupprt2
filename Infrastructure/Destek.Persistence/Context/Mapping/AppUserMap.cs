using Destek.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Context.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> b)
        {
            b.Property(x => x.FirstName).IsRequired();
            b.Property(x => x.FirstName).HasMaxLength(250);
            b.Property(x => x.LastName).IsRequired();
            b.Property(x => x.LastName).HasMaxLength(250);
            b.Property(x => x.TCKN).IsRequired();
            b.Property(x => x.TCKN).HasMaxLength(100);
            b.HasIndex(x => x.TCKN).IsUnique();
            b.Property(x => x.RefreshToken).HasMaxLength(500);
            b.Property(x => x.RefreshToken).IsRequired(false);
            b.Property(u => u.RefreshTokenEndDate).IsRequired(false);
            b.Property(u => u.PhoneNumber).IsRequired(false);
            b.Property(u => u.PhoneNumber).HasMaxLength(30);
            b.Property(u => u.PasswordHash).HasMaxLength(1000);
            b.Property(u => u.SecurityStamp).HasMaxLength(2000);
            b.Property(u => u.ConcurrencyStamp).HasMaxLength(2000);

            // Primary key
            b.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex").IsUnique();
           

           

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.UserName).HasMaxLength(50);
            b.Property(u => u.NormalizedUserName).HasMaxLength(50);
            b.Property(u => u.Email).HasMaxLength(100);
            b.Property(u => u.NormalizedEmail).HasMaxLength(100);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            b.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            b.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            b.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            // Maps to the AspNetUsers table
            b.ToTable("AppUsers");

            //b.HasMany<Article>().WithOne().HasForeignKey(rc => rc.UserId).IsRequired();
            //b.HasMany<Dil>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            //var adminUser = new AppUser
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "Admin",
            //    NormalizedUserName = "ADMIN",
            //    Email = "burhanozdemir.01@gmail.com",
            //    NormalizedEmail = "BURHANOZDEMIR.01@GMAIL.COM",
            //    PhoneNumber = "+905466279280",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    TCKN = Guid.NewGuid().ToString(),
            //    FirstName = "Admin",
            //    LastName = "Admin",
            //};
            //adminUser.PasswordHash = CreatePasswordHash(adminUser, "123456");
            //b.HasData(adminUser);
            //var adminUser2 = new AppUser
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = "burhan",
            //    NormalizedUserName = "BURHAN",
            //    Email = "burhan.ozdemir@sirnak.edu.tr",
            //    NormalizedEmail = "BURHAN.OZDEMIR@SIRNAK.EDU.TR",
            //    PhoneNumber = "+905466279280",
            //    EmailConfirmed = true,
            //    PhoneNumberConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    TCKN = Guid.NewGuid().ToString(),
            //    FirstName = "Burhan",
            //    LastName = "Özdemir",
            //};
            //adminUser2.PasswordHash = CreatePasswordHash(adminUser2, "123456");
            //b.HasData(adminUser2);

        }

        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
