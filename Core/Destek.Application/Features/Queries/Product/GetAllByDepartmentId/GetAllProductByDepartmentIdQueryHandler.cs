using Destek.Application.DTOs.Product;
using Destek.Application.Repositories.ProductRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Product.GetAllByDepartmentId
{
    public class GetAllProductByDepartmentIdQueryHandler(IProductReadRepository productReadRepository) : IRequestHandler<GetAllProductByDepartmentIdQueryRequest, GetAllProductByDepartmentIdQueryResponse>
    {
        public async Task<GetAllProductByDepartmentIdQueryResponse> Handle(GetAllProductByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = productReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.WarehouseCategory.DepartmentId == Guid.Parse(request.DepartmentId)).Include(x => x.WarehouseCategory).Include(x=>x.Brand);

            IQueryable<d.Product> queryProduct = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryProduct = query.Where(x => (x.WarehouseCategory.Name.Contains(request.Search) || x.Brand.Name.Contains(request.Search) || x.Name.Contains(request.Search) || x.SerialNumber.Contains(request.Search) || x.Barcode.Contains(request.Search)));
                totalCount = queryProduct.Count();
            }
            else
            {
                queryProduct = query;
                totalCount = query.Count();

            }

            var datas = queryProduct.Skip(request.Size * request.Page).Take(request.Size).Select(data => new ProductModelDto
            {
                Id = data.Id.ToString(),
                WarehouseCategoryName = data.WarehouseCategory.Name,
                BrandName = data.Brand.Name,
                Name = data.Name,
                SerialNumber = data.SerialNumber,
                Barcode = data.Barcode,
                UnitOfMeasureType = data.UnitOfMeasureType,
                UnitsInStock = data.UnitsInStock,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllProductByDepartmentIdQueryResponse
            {
                TotalCount = totalCount,
                Products = datas
            };
        }
    }
}
