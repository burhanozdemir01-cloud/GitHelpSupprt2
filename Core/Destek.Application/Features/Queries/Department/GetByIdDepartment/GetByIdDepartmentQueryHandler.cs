using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Department.GetByIdDepartment
{
    public class GetByIdDepartmentQueryHandler(IDepartmentReadRepository departmentReadRepository) : IRequestHandler<GetByIdDepartmentQueryRequest, GetByIdDepartmentQueryResponse>
    {
        public async Task<GetByIdDepartmentQueryResponse> Handle(GetByIdDepartmentQueryRequest request, CancellationToken cancellationToken)
        {
            d.Department department = await departmentReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
               Id=department.Id,
                Name = department.Name,
                FullName = department.FullName,
                IsPublish=department.IsPublish,
                IsActive=department.IsActive,
            };
        }
    }
}
