using Destek.Application.Repositories.DepartmentRepo;
using Destek.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d= Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.DepartmentFile.RemoveDepartmentFile
{
    public class RemoveDepartmentFileCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository) : IRequestHandler<RemoveDepartmentFileCommandRequest, RemoveDepartmentFileCommandResponse>
    {
        public async Task<RemoveDepartmentFileCommandResponse> Handle(RemoveDepartmentFileCommandRequest request, CancellationToken cancellationToken)
        {
            d.Department department = await departmentReadRepository.Table.Include(p => p.DepartmentFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
            d.DepartmentFile? departmentFile = department?.DepartmentFiles.FirstOrDefault(p => p.Id == Guid.Parse(request.ImageId));
            if (departmentFile != null)
                department?.DepartmentFiles.Remove(departmentFile);
            await departmentWriteRepository.SaveAsync();
            return new();
        }
    }
}
