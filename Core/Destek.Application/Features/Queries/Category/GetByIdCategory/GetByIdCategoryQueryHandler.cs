
using Destek.Application.Repositories.CategoryRepo;
using MediatR;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository) : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            c.Category category = await categoryReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
               Id = category.Id,
                DepartmentId= category.DepartmentId,
                Name= category.Name,
                SequenceNumber= category.SequenceNumber,
                IsActive= category.IsActive,
            };
        }
    }
}
