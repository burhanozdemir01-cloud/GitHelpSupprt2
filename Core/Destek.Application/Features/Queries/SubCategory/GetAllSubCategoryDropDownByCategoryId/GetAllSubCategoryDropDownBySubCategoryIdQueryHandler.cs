using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.SubCategory.GetAllSubCategoryDropDownByCategoryId
{
    public class GetAllSubCategoryDropDownBySubCategoryIdQueryHandler(ISubCategoryReadRepository subCategoryReadRepository) : IRequestHandler<GetAllSubCategoryDropDownBySubCategoryIdQueryRequest, GetAllSubCategoryDropDownBySubCategoryIdQueryResponse>
    {
        public async Task<GetAllSubCategoryDropDownBySubCategoryIdQueryResponse> Handle(GetAllSubCategoryDropDownBySubCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var subCategories = subCategoryReadRepository.GetAll(false).Where(x => x.CategoryId == Guid.Parse(request.CategoryId)).Select(p => new
            {
                p.Id,
                p.Name,
            }).ToList();

            return new()
            {
                SubCategories = subCategories,
            };
        }
    }
}
