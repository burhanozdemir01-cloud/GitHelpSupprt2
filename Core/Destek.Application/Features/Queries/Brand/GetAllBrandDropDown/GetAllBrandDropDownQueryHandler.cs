using Destek.Application.DTOs.Brand;
using Destek.Application.Features.Queries.Brand.GetAllByDepartmentId;
using Destek.Application.Repositories.BrandRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Brand.GetAllBrandDropDown
{
    public class GetAllBrandDropDownQueryHandler(IBrandReadRepository brandReadRepository) : IRequestHandler<GetAllBrandDropDownQueryRequest, GetAllBrandDropDownQueryResponse>
    {
        public async Task<GetAllBrandDropDownQueryResponse> Handle(GetAllBrandDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            var query = brandReadRepository.GetWhere(x => !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId),false);
            var datas = query.Select(data => new BrandListDropDownDto
            {
                Id = data.Id.ToString(),
                Name = data.Name,

            }).ToList();

            return new GetAllBrandDropDownQueryResponse
            {
                Brands = datas
            };
        }
    }
}
