using MediatR;

namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByTicketId
{
    public class GetAllWarehouseTransactionByTicketIdQueryRequest:IRequest<GetAllWarehouseTransactionByTicketIdQueryResponse>
    {
        public string TicketId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
