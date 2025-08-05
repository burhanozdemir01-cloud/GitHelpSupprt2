using Destek.Application.Abstractions.Hubs;
using Destek.Application.DTOs.Ticket;
using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryHandler(IDepartmentReadRepository departmentReadRepository, IDepartmentHubService departmentHubService) : IRequestHandler<GetAllDepartmentQueryRequest, GetAllDepartmentQueryResponse>
    {
        public async Task<GetAllDepartmentQueryResponse> Handle(GetAllDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            var query = departmentReadRepository.GetAll(false);
            var queryTotal = departmentReadRepository.GetAll(false);
            IQueryable<d.Department> queryDepartment = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {
                totalCount = queryTotal.Where(x => x.Name.Contains(request.Search) || x.FullName.Contains(request.Search)).Count();
                queryDepartment = query.Where(x => x.Name.Contains(request.Search) || x.FullName.Contains(request.Search));
            }
            else
            {
                queryDepartment = query;
                totalCount = departmentReadRepository.GetAll(false).Count();

            }
       
            var departments = queryDepartment.Skip(request.Size * request.Page).Take(request.Size).Include(p => p.DepartmentFiles).Select(p => new
            {
                p.Id,
                p.Name,
                p.FullName,
                p.IsPublish,
                p.IsActive,
                p.CreatedDate,
                p.DepartmentFiles
            }).ToList();

            return new()
            {
                Departments = departments,
                TotalCount = totalCount,
            };

        }
    }
}
