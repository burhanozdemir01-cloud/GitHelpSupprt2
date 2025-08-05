using Destek.Application.Repositories.WarehouseRepo;
using MediatR;

namespace Destek.Application.Features.Queries.Warehouse.GetById
{
    public class GetWarehouseIdQueryHandler(IWarehouseReadRepository warehouseReadRepository) : IRequestHandler<GetWarehouseIdQueryRequest, GetWarehouseIdQueryResponse>
    {
        public async Task<GetWarehouseIdQueryResponse> Handle(GetWarehouseIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await warehouseReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = data.Id.ToString(),
                DepartmentId = data.DepartmentId.ToString(),
                Name = data.Name,
                Location = data.Location,
                IsDelete = data.IsDeleted,
                IsActive = data.IsActive,
            };
            
        }
    }
}
