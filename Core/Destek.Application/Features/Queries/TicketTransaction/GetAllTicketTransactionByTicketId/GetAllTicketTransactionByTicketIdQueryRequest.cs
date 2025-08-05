using MediatR;

namespace Destek.Application.Features.Queries.TicketTransaction.GetAllTicketTransactionByTicketId
{
    public class GetAllTicketTransactionByTicketIdQueryRequest:IRequest<GetAllTicketTransactionByTicketIdQueryResponse>
    {
       
        public string TicketId { get; set; }
    }
}
