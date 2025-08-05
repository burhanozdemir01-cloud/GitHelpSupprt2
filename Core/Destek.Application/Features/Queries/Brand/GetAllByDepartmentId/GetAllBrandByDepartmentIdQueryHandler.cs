using Destek.Application.DTOs.Brand;
using Destek.Application.DTOs.WarehouseCategory;
using Destek.Application.Features.Queries.WarehouseCategory.GetAllByDepartmentId;
using Destek.Application.Repositories.BrandRepo;
using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Brand.GetAllByDepartmentId
{
    public class GetAllBrandByDepartmentIdQueryHandler(IBrandReadRepository brandReadRepository) : IRequestHandler<GetAllBrandByDepartmentIdQueryRequest, GetAllBrandByDepartmentIdQueryResponse>
    {
        public async Task<GetAllBrandByDepartmentIdQueryResponse> Handle(GetAllBrandByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = brandReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId)).Include(x => x.Department);

            IQueryable<d.Brand> queryBrand = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryBrand = query.Where(x => (x.Department.Name.Contains(request.Search) || x.Name.Contains(request.Search)));
                totalCount = queryBrand.Count();
            }
            else
            {
                queryBrand = query;
                totalCount = query.Count();

            }

            var datas = queryBrand.Skip(request.Size * request.Page).Take(request.Size).Select(data => new BrandModelDto
            {
                Id = data.Id.ToString(),
                DepartmentName = data.Department.Name,
                Name = data.Name,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllBrandByDepartmentIdQueryResponse
            {
                TotalCount = totalCount,
                Brands = datas
            };
        }
    }
}
