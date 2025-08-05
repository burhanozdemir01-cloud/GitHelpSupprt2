using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Department.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository) : IRequestHandler<UpdateDepartmentCommandRequest, UpdateDepartmentCommandResponse>
    {
        public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            d.Department department = await departmentReadRepository.GetByIdAsync(request.Id);
            department.Name = request.Name;
            department.FullName = request.FullName;
            department.IsActive = request.IsActive;
            department.IsPublish= request.IsPublish;
            await departmentWriteRepository.SaveAsync();
            return new();
        }
    }
}
