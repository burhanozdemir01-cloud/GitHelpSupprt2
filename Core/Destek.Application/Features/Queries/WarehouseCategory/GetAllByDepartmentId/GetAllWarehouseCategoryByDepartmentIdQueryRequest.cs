using MediatR;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetAllByDepartmentId
{
    public class GetAllWarehouseCategoryByDepartmentIdQueryRequest : IRequest<GetAllWarehouseCategoryByDepartmentIdQueryResponse>
    {
        public string DepartmentId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
