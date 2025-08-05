using Destek.Application.DTOs.WarehouseCategory;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetAllByDepartmentId
{
    public class GetAllWarehouseCategoryByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<WarehouseCategoryModelDto> WarehouseCategories { get; set; }
    }
}
