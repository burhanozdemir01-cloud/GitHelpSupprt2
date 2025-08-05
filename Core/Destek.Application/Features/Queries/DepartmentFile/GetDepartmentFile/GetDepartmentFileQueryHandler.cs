using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.DepartmentFile.GetDepartmentFile
{
    public class GetDepartmentFileQueryHandler(IDepartmentReadRepository departmentReadRepository, IConfiguration configuration) : IRequestHandler<GetDepartmentFileQueryRequest, List<GetDepartmentFileQueryResponse>>
    {
        public async Task<List<GetDepartmentFileQueryResponse>> Handle(GetDepartmentFileQueryRequest request, CancellationToken cancellationToken)
        {

            d.Department department = await departmentReadRepository.Table.Include(p => p.DepartmentFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            if (department != null)
                return department.DepartmentFiles.Select(p => new GetDepartmentFileQueryResponse
                {
                    Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
                    FileName = p.FileName,
                    Id = p.Id,
                    DepartmentId=request.Id,
                }).ToList();



            return new();
        }
    }
}
