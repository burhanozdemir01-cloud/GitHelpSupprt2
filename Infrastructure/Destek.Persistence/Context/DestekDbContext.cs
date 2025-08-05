using Destek.Application.Exceptions;
using Destek.Domain.Entities;
using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;
using Destek.Persistence.Context.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;

namespace Destek.Persistence.Context
{
    public class DestekDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DestekDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //public DestekDbContext(DbContextOptions<DestekDbContext> options) : base(options)
        //{

        //}

        public DbSet<Department> Departments { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CommonFile> CommonFiles { get; set; }
        public DbSet<DepartmentFile> DepartmentFile { get; set; }
        public DbSet<TicketFile> TicketFiles { get; set; }

        public DbSet<ControllerMenu> ControllerMenus { get; set; }
        public DbSet<ControllerEndpoint> ControllerEndpoints { get; set; }
        public DbSet<ProcessingTime> ProcessingTimes { get; set; }

        public DbSet<TicketAssign> TicketAssigns { get; set; }
        public DbSet<TicketLocked> TicketLockeds { get; set; }
        public DbSet<TicketUnnecessary> TicketUnnecessaries { get; set; }
        public DbSet<TicketTransaction> TicketTransactions { get; set; }
        public DbSet<TicketTransactionFile> TicketTransactionFiles { get; set; }

        //Warehouse tables
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseCategory> WarehouseCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }   
        public DbSet<WarehouseTransaction> WarehouseTransactions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var userName = "";
            //if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated == false)
            //    userName = null;
            //userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userName = _httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated != null || true ? _httpContextAccessor.HttpContext.User.Identity.Name : null;
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                //_ = data.State switch
                //{
                //    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                //    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                //    _ => DateTime.Now
                //};

                switch (data.State)
                {
                    case EntityState.Added: { data.Entity.CreatedDate = DateTime.Now; data.Entity.CreatedByName = userName; data.Entity.ModifiedByName = ""; break; }
                    case EntityState.Modified: { data.Entity.UpdatedDate = DateTime.Now; data.Entity.ModifiedByName = userName; break; }
                    default: { break; }
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           

            builder.ApplyConfiguration(new AppRoleClaimMap());
            builder.ApplyConfiguration(new AppRoleMap());
            builder.ApplyConfiguration(new AppUserClaimMap());
            builder.ApplyConfiguration(new AppUserLoginMap());
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new AppUserTokenMap());
            builder.ApplyConfiguration(new AppUserRoleMap());

            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new CommonFileMap());
            builder.ApplyConfiguration(new ControllerEndpointMap());
            builder.ApplyConfiguration(new ControllerMenuMap());
            builder.ApplyConfiguration(new DepartmentMap());
            builder.ApplyConfiguration(new SubCategoryMap());
            builder.ApplyConfiguration(new TicketMap());

            builder.ApplyConfiguration(new ProcessingTimeMap());
            builder.ApplyConfiguration(new TicketAssignMap());
            builder.ApplyConfiguration(new TicketLockedMap());
            builder.ApplyConfiguration(new TicketUnnecessaryMap());
            builder.ApplyConfiguration(new TicketTransactionMap());

            //Warehouse tables Map

            builder.ApplyConfiguration(new WarehouseMap());
            builder.ApplyConfiguration(new WarehouseCategoryMap());
            builder.ApplyConfiguration(new BrandMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new WarehouseTransactionMap());
        }
    }
}
