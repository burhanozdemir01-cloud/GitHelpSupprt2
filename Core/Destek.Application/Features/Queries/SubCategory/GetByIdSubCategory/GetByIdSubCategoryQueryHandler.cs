using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using MediatR;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.SubCategory.GetByIdSubCategory
{
    public class GetByIdSubCategoryQueryHandler(ISubCategoryReadRepository subCategoryReadRepository) : IRequestHandler<GetByIdSubCategoryQueryRequest, GetByIdSubCategoryQueryResponse>
    {
        public async Task<GetByIdSubCategoryQueryResponse> Handle(GetByIdSubCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            c.SubCategory subCategory = await subCategoryReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                Id = subCategory.Id,
                CategoryId = subCategory.CategoryId,
                Name = subCategory.Name,
                SequenceNumber = subCategory.SequenceNumber,
                IsActive = subCategory.IsActive,
            };
        }
    }
}
