using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.WarehouseTransaction.GelAllByWarehouseId
{
    public class GetAllWarehouseTransactionByWarehouseIdQueryRequest:IRequest<GetAllWarehouseTransactionByWarehouseIdQueryResponse>
    {
        public string WarehouseId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
