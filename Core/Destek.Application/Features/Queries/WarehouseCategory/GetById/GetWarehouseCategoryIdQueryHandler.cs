using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetById
{
    public class GetWarehouseCategoryIdQueryHandler(IWarehouseCategoryReadRepository warehouseCategoryReadRepository) : IRequestHandler<GetWarehouseCategoryIdQueryRequest, GetWarehouseCategoryIdQueryResponse>
    {
        public async Task<GetWarehouseCategoryIdQueryResponse> Handle(GetWarehouseCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await warehouseCategoryReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = data.Id.ToString(),
                DepartmentId = data.DepartmentId.ToString(),
                Name = data.Name,
                IsDelete = data.IsDeleted,
                IsActive = data.IsActive,
            };
        }
    }
}
