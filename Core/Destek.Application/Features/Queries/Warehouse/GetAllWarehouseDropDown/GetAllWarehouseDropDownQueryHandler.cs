using Destek.Application.DTOs.Warehouse;
using Destek.Application.Repositories.WarehouseRepo;
using MediatR;

namespace Destek.Application.Features.Queries.Warehouse.GetAllWarehouseDropDown
{
    public class GetAllWarehouseDropDownQueryHandler(IWarehouseReadRepository warehouseReadRepository) : IRequestHandler<GetAllWarehouseDropDownQueryRequest, GetAllWarehouseDropDownQueryResponse>
    {
        public async Task<GetAllWarehouseDropDownQueryResponse> Handle(GetAllWarehouseDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseReadRepository.GetWhere(x => x.IsActive && !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId), false);
            var datas = query.Select(data => new WarehouseListDropDownDto
            {
                Id = data.Id.ToString(),
                Name = data.Name,

            }).ToList();

            return new GetAllWarehouseDropDownQueryResponse
            {
                Warehouses = datas
            };
        }
    }
}
