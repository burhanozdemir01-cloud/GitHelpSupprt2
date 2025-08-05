using MediatR;

namespace Destek.Application.Features.Queries.Ticket.GetLockedTickets
{
    public class GetLockedTicketsQueryRequest:IRequest<GetLockedTicketsQueryResponse>
    {
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
        public bool IsLocked { get; set; }
    }
}
