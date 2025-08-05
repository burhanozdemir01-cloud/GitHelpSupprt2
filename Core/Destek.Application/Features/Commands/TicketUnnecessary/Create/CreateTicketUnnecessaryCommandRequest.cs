using MediatR;

namespace Destek.Application.Features.Commands.TicketUnnecessary.Create
{
    public class CreateTicketUnnecessaryCommandRequest:IRequest<CreateTicketUnnecessaryCommandResponse>
    {
        public string TicketId { get; set; }

        public string Note { get; set; }
    }
}
