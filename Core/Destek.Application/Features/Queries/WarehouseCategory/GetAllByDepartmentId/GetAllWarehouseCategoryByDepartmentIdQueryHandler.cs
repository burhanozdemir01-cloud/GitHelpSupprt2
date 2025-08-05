using Destek.Application.DTOs.WarehouseCategory;
using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.WarehouseCategory.GetAllByDepartmentId
{
    public class GetAllWarehouseCategoryByDepartmentIdQueryHandler(IWarehouseCategoryReadRepository warehouseCategoryReadRepository) : IRequestHandler<GetAllWarehouseCategoryByDepartmentIdQueryRequest, GetAllWarehouseCategoryByDepartmentIdQueryResponse>
    {
        public async Task<GetAllWarehouseCategoryByDepartmentIdQueryResponse> Handle(GetAllWarehouseCategoryByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseCategoryReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId)).Include(x => x.Department);

            IQueryable<d.WarehouseCategory> queryWarehouseCategory = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryWarehouseCategory = query.Where(x => (x.Department.Name.Contains(request.Search) || x.Name.Contains(request.Search)));
                totalCount = queryWarehouseCategory.Count();
            }
            else
            {
                queryWarehouseCategory = query;
                totalCount = query.Count();

            }

            var datas = queryWarehouseCategory.Skip(request.Size * request.Page).Take(request.Size).Select(data => new WarehouseCategoryModelDto
            {
                Id = data.Id.ToString(),
                DepartmentName = data.Department.Name,
                Name = data.Name,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllWarehouseCategoryByDepartmentIdQueryResponse
            {
                TotalCount = totalCount,
                WarehouseCategories = datas
            };
        }
    }
}
