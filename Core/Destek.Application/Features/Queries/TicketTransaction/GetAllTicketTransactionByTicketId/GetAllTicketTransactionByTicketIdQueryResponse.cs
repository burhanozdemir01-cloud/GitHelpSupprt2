using Destek.Application.DTOs.Ticket;
using Destek.Application.DTOs.TicketTransaction;

namespace Destek.Application.Features.Queries.TicketTransaction.GetAllTicketTransactionByTicketId
{
    public class GetAllTicketTransactionByTicketIdQueryResponse
    {

        public int TotalCount { get; set; }
        public List<TicketTransactionModelDto> TicketTransactions { get; set; }
        //public object TicketTransactions { get; set; }
    }
}
