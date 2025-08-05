using Destek.Application.Repositories.BrandRepo;
using MediatR;

namespace Destek.Application.Features.Queries.Brand.GetById
{
    public class GetBrandIdQueryHandler(IBrandReadRepository brandReadRepository) : IRequestHandler<GetBrandIdQueryRequest, GetBrandIdQueryResponse>
    {
        public async Task<GetBrandIdQueryResponse> Handle(GetBrandIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await brandReadRepository.GetByIdAsync(request.Id, false);
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
