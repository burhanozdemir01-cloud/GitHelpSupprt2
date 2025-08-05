using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByDepartmentId
{
    public class GetAllWarehouseTransactionByDepartmentIdQueryRequest:IRequest<GetAllWarehouseTransactionByDepartmentIdQueryResponse>
    {
        public string DepartmentId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
