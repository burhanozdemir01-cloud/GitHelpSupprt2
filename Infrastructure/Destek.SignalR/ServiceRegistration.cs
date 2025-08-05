using Destek.Application.Abstractions.Hubs;
using Destek.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace Destek.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IDepartmentHubService, DepartmentHubService>();
           // collection.AddTransient<IOrderHubService, OrderHubService>();
            collection.AddSignalR();
        }
    }

}
