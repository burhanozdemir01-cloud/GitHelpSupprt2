using Destek.Application.DTOs.Ticket;

namespace Destek.Application.Features.Queries.Ticket.GetLockedTickets
{
    public class GetLockedTicketsQueryResponse
    {
        public int TotalCount { get; set; }

        public List<TicketModelDto> Tickets { get; set; }
    }
}
