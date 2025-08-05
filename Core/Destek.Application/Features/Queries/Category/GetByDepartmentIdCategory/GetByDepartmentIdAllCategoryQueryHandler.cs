using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.DepartmentFileRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory
{
    public class GetByDepartmentIdAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IDepartmentFileReadRepository departmentFileReadRepository,ISubCategoryReadRepository subCategoryReadRepository) : IRequestHandler<GetByDepartmentIdAllCategoryQueryRequest, GetByDepartmentIdAllCategoryQueryResponse>
    {
        public async Task<GetByDepartmentIdAllCategoryQueryResponse> Handle(GetByDepartmentIdAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
      
            var categories =categoryReadRepository.GetAll(false).Include(x=>x.SubCategories).Where(x=>x.DepartmentId==Guid.Parse(request.DepartmentId)).OrderBy(x => x.SequenceNumber).Select(p => new
            {
                p.Id,
                p.Name,
                p.SequenceNumber,
                p.IsActive,
                p.CreatedDate,
                p.SubCategories

            }).ToList(); ;

            return new()
            {
                Categories = categories,
              

            };
        }
    }
}
