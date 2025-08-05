using Destek.Domain.Enums;
using MediatR;

namespace Destek.Application.Features.Commands.WarehouseTransaction.RemoveForTicket
{
    public class RemoveForTicketWarehouseTransactionCommandRequest:IRequest<RemoveForTicketWarehouseTransactionCommandResponse>
    {
        public string TicketId { get; set; }
        public string WarehouseId { get; set; }
        public string ProductId { get; set; }
        public decimal Quantity { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
