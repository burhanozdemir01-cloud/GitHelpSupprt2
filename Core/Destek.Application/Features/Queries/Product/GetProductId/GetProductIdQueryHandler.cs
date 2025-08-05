using Destek.Application.Repositories.ProductRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Destek.Application.Features.Queries.Product.GetProductId
{
    public class GetProductIdQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetProductIdQueryRequest, GetProductIdQueryResponse>
    {
        public async Task<GetProductIdQueryResponse> Handle(GetProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            var data = productReadRepository.GetWhere(x=>x.Id==Guid.Parse(request.Id)).Include(x=>x.Brand).SingleOrDefault();
            return new()
            {

                Id = data.Id.ToString(),
                DepartmentId=data.Brand.DepartmentId.ToString(),
                WarehouseCategoryId = data.WarehouseCategoryId.ToString(),
                BrandId = data.BrandId.ToString(),
                Name = data.Name,
                SerialNumber = data.SerialNumber,
                Barcode = data.Barcode,
                UnitOfMeasureType = data.UnitOfMeasureType,
                UnitsInStock = data.UnitsInStock,
                IsDelete = data.IsDeleted,
                IsActive = data.IsActive,
            };
        }
    }
}
