using MediatR;

namespace Destek.Application.Features.Commands.TicketAssign.DeleteTicketAssign
{
    public class RemoveTicketAssignCommandRequest:IRequest<RemoveTicketAssignCommandResponse>
    {
        public string Id { get; set; }
    }
}
