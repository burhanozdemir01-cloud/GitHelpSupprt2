using Destek.Application.DTOs.Product;
using Destek.Application.Helpers;
using Destek.Application.Repositories.ProductRepo;
using MediatR;

namespace Destek.Application.Features.Queries.Product.GetAllProductDropDown
{
    public class GetAllProductDropDownQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetAllProductDropDownQueryRequest, GetAllProductDropDownQueryResponse>
    {
        public async Task<GetAllProductDropDownQueryResponse> Handle(GetAllProductDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            var query = productReadRepository.GetWhere(x => !x.IsDeleted && x.WarehouseCategory.DepartmentId == Guid.Parse(request.DepartmentId), false);
            var datas = query.Select(data => new ProductListDropDownDto
            {
                Id = data.Id.ToString(),
                Name =$"{data.Name} - {data.Brand.Name} / {data.UnitsInStock} ({UnitOfMeasureHelper.GetDisplayName(data.UnitOfMeasureType)})",

            }).ToList();

            return new GetAllProductDropDownQueryResponse
            {
                Products = datas
            };
        }
    }
}
