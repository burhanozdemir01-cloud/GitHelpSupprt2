using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Destek.Application
{
    public static class ServiceRegistraction
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddSingleton<IProductService,ProductService>();

            services.AddMediatR(typeof(ServiceRegistraction));


        }
    }
}
