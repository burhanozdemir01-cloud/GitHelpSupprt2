using Destek.Application.DTOs.WarehouseTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByDepartmentId
{
    public class GetAllWarehouseTransactionByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<WarehouseTransactionModelDto> WarehouseTransactions { get; set; }
    }
}
