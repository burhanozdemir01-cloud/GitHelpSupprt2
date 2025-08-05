using MediatR;

namespace Destek.Application.Features.Queries.Warehouse.GetAllWarehouseDropDown
{
    public class GetAllWarehouseDropDownQueryRequest:IRequest<GetAllWarehouseDropDownQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
