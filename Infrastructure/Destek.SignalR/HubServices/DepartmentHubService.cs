using Destek.Application.Abstractions.Hubs;
using Destek.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Destek.SignalR.HubServices
{
    public class DepartmentHubService : IDepartmentHubService
    {
        readonly IHubContext<DepartmentHub> _hubContext;

        public DepartmentHubService(IHubContext<DepartmentHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task DepartmentAddedMessageAsync(string message)
        {

            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.DepartmentAddedMessage, message);



        }

    }
}
