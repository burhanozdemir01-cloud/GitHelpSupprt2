using Destek.Application.DTOs.Brand;
using Destek.Application.DTOs.WarehouseCategory;
using Destek.Application.Features.Queries.Brand.GetAllBrandDropDown;
using Destek.Application.Repositories.BrandRepo;
using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetAllWarehouseCategoryDropDown
{
    internal class GetAllWarehouseCategoryDropDownQueryHandler(IWarehouseCategoryReadRepository warehouseCategoryReadRepository) : IRequestHandler<GetAllWarehouseCategoryDropDownQueryRequest, GetAllWarehouseCategoryDropDownQueryResponse>
    {
        public async Task<GetAllWarehouseCategoryDropDownQueryResponse> Handle(GetAllWarehouseCategoryDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseCategoryReadRepository.GetWhere(x => !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId), false);
            var datas = query.Select(data => new WarehouseCategoryListDropDown
            {
                Id = data.Id.ToString(),
                Name = data.Name,

            }).ToList();

            return new GetAllWarehouseCategoryDropDownQueryResponse
            {
                WarehouseCategories = datas
            };
        }
    }
}
