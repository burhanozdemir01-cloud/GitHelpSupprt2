using Destek.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.WarehouseTransaction.Create
{
    public class CreateWarehouseTransactionCommandRequest:IRequest<CreateWarehouseTransactionCommandResponse>
    {
        public string WarehouseId { get; set; }
        public string ProductId { get; set; }
        public decimal Quantity { get; set; }
        public TransactionType TransactionType { get; set; }

       
    }
}
