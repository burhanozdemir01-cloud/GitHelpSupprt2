

using Destek.Domain.Entities.Identity;
using Destek.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Destek.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DestekDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });

            services.AddIdentity<AppUser, AppRole>(action =>
            {
                action.Password.RequiredLength = 1;
                action.Password.RequireUppercase = false;
                action.Password.RequireLowercase = false;
                action.Password.RequireNonAlphanumeric = false;
                action.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<DestekDbContext>().AddDefaultTokenProviders();


            services.Scan(act =>
            {
                act
                .FromAssemblies(typeof(ServiceRegistration).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(registrationStrategy: Scrutor.RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
            return services;

        }
    }
}
