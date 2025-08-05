using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.WarehouseTransaction.Cancel
{
    public class CancelWarehouseTransactionCommandRequest:IRequest<CancelWarehouseTransactionCommandResponse>
    {
        public string Id { get; set; }
    }
}
