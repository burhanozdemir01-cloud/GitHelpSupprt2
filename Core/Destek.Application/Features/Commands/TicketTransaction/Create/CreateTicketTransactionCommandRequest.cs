using MediatR;
using Microsoft.AspNetCore.Http;

namespace Destek.Application.Features.Commands.TicketTransaction.Create
{
    public class CreateTicketTransactionCommandRequest:IRequest<CreateTicketTransactionCommandResponse>
    {
        public string TicketId { get; set; }
        public string Description { get; set; }

        public IFormFileCollection? Files { get; set; }
    }
}
