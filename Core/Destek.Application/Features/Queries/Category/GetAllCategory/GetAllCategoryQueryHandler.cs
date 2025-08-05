using Destek.Application.Repositories.CategoryRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository) : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            
            var query = categoryReadRepository.GetAll(false);
            var queryTotal = categoryReadRepository.GetAll(false);
            IQueryable<d.Category> queryCategory = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {
                totalCount = queryTotal.Where(x => x.Name.Contains(request.Search)).Count();
                queryCategory = query.Where(x => x.Name.Contains(request.Search));
            }
            else
            {
                queryCategory = query;
                totalCount = categoryReadRepository.GetAll(false).Count();

            }
           
            var categories = queryCategory.Skip(request.Size * request.Page).Include(x=>x.Department).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.SequenceNumber,
                p.IsActive,
                p.CreatedDate,
                p.DepartmentId,
                p.Department

            }).ToList(); ;

            return new()
            {
                Categories = categories,
                TotalCount = totalCount,

            };
        }
    }
}
