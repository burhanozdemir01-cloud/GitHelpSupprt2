using Destek.Application.DTOs.Warehouse;
using Destek.Application.Repositories.DepartmentRepo;
using Destek.Application.Repositories.WarehouseRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Warehouse.GetAllByDepartmentId
{
    public class GetAllWarehouseByDepartmentIdQueryHandler(IWarehouseReadRepository warehouseReadRepository,IDepartmentReadRepository departmentReadRepository) : IRequestHandler<GetAllWarehouseByDepartmentIdQueryRequest, GetAllWarehouseByDepartmentIdQueryResponse>
    {
        public async Task<GetAllWarehouseByDepartmentIdQueryResponse> Handle(GetAllWarehouseByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.DepartmentId==Guid.Parse(request.DepartmentId)).Include(x => x.Department);

            IQueryable<d.Warehouse> queryWarehouse = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryWarehouse = query.Where(x => (x.Department.Name.Contains(request.Search) || x.Name.Contains(request.Search) || x.Location.Contains(request.Search)));
                totalCount = queryWarehouse.Count();
            }
            else
            {
                queryWarehouse = query;
                totalCount = query.Count();

            }

            var datas = queryWarehouse.Skip(request.Size * request.Page).Take(request.Size).Select(data => new WarehouseModelDto
            {
                Id = data.Id.ToString(),
                DepartmentName = data.Department.Name,
                Name = data.Name,
                Location = data.Location,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllWarehouseByDepartmentIdQueryResponse
            {
                TotalCount = totalCount,
                Warehouses = datas
            };

        }
    }
}
