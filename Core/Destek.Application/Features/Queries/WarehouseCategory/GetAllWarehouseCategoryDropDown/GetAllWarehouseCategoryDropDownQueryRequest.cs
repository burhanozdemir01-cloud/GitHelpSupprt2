using MediatR;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetAllWarehouseCategoryDropDown
{
    public class GetAllWarehouseCategoryDropDownQueryRequest:IRequest<GetAllWarehouseCategoryDropDownQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
