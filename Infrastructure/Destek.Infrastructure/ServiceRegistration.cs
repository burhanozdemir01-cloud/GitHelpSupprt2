using Destek.Application.Abstractions.Storage;
using Destek.Infrastructure.Enums;
using Destek.Infrastructure.Services.Storage.Local;
using Destek.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Destek.Domain.Enums;
using Destek.Application.Abstractions.Token;
using Destek.Infrastructure.Services.Token;
using Destek.Application.Abstractions.Services;
using Destek.Infrastructure.Services;
using Destek.Application.Abstractions.Services.Configurations;
using Destek.Infrastructure.Services.Configurations;

namespace Destek.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddSingleton<IProductService,ProductService>();

            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IApplicationService, ApplicationService>();



            //services.AddScoped<IFileService, FileService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }

        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                   
                    break;
                case StorageType.AWS:
                    //    services.AddScoped<IStorage, Az>();
                    break;
                default:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
            }
        }
    }
}
