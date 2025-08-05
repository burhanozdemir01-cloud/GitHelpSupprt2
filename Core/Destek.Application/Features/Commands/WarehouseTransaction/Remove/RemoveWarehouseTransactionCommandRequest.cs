using Destek.Domain.Enums;
using MediatR;

namespace Destek.Application.Features.Commands.WarehouseTransaction.Remove
{
    public class RemoveWarehouseTransactionCommandRequest:IRequest<RemoveWarehouseTransactionCommandResponse>
    {
        public string WarehouseId { get; set; }
        public string ProductId { get; set; }
        public decimal Quantity { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
