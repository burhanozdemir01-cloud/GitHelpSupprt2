using Destek.Application.DTOs.WarehouseTransaction;

namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByTicketId
{
    public class GetAllWarehouseTransactionByTicketIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<WarehouseTransactionModelDto> WarehouseTransactions { get; set; }
    }
}
