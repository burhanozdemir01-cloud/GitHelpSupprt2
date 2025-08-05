using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Department.GetAllDepartmentDropDown
{
    public class GetAllDepartmentDropDownQueryHandler(IDepartmentReadRepository departmentReadRepository) : IRequestHandler<GetAllDepartmentDropDownQueryRequest, GetAllDepartmentDropDownQueryResponse>
    {
        public async Task<GetAllDepartmentDropDownQueryResponse> Handle(GetAllDepartmentDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            var query = departmentReadRepository.GetAll(false);
            IQueryable<d.Department> queryDepartment = null;
            if (request.IsPublish)
            {

                queryDepartment = query.Where(x => x.IsActive && x.IsPublish == request.IsPublish && !x.IsDeleted);
            }
            else
            {
                queryDepartment = query;
              

            }

            var departments = queryDepartment.Select(p => new
            {
                p.Id,
                p.Name,

            }).ToList();

            return new()
            {
                Departments = departments,

            };
           
        }
    }
}
