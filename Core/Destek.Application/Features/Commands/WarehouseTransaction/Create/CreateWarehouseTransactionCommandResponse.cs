using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.WarehouseTransaction.Create
{
    public class CreateWarehouseTransactionCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
