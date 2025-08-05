using MediatR;

namespace Destek.Application.Features.Commands.TicketAssign.UpdateTicketAssign
{
    public class UpdateTicketAssignCommandRequest:IRequest<UpdateTicketAssignCommandResponse>
    {
        public string Id { get; set; }
        public int JobCountOrExtraPoint { get; set; }
        public bool IsJobCount { get; set; }
    }
}
