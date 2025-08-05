using MediatR;

namespace Destek.Application.Features.Queries.Warehouse.GetAllByDepartmentId
{
    public class GetAllWarehouseByDepartmentIdQueryRequest:IRequest<GetAllWarehouseByDepartmentIdQueryResponse>
    {
        public string DepartmentId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
