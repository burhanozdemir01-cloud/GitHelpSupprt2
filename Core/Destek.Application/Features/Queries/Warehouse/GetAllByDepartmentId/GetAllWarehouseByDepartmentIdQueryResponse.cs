using Destek.Application.DTOs.Warehouse;

namespace Destek.Application.Features.Queries.Warehouse.GetAllByDepartmentId
{
    public class GetAllWarehouseByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<WarehouseModelDto> Warehouses { get; set; }
    }
}
