using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Category.GetAllCategoryDropDownByDepartmentId
{
    public class GetAllCategoryDropDownByDepartmentIdQueryHandler(ICategoryReadRepository categoryReadRepository) : IRequestHandler<GetAllCategoryDropDownByDepartmentIdQueryRequest, GetAllCategoryDropDownByDepartmentIdQueryResponse>
    {
        public async Task<GetAllCategoryDropDownByDepartmentIdQueryResponse> Handle(GetAllCategoryDropDownByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = categoryReadRepository.GetAll(false).Where(x=>x.DepartmentId==Guid.Parse(request.DepartmentId)).Select(p => new
            {
                p.Id,
                p.Name,
            }).ToList();

            return new()
            {
                Categories = categories,
            };
        }
    }
}
