using Destek.Application.Abstractions.Hubs;
using Destek.Application.Repositories.DepartmentRepo;
using MediatR;

namespace Destek.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandHandler(IDepartmentWriteRepository departmentWriteRepository) : IRequestHandler<CreateDepartmentCommandRequest, CreateDepartmentCommandResponse>
    {
        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await departmentWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                FullName = request.FullName,
                IsPublish = request.IsPublish,
                IsActive=true,
            });
            await departmentWriteRepository.SaveAsync();
        
            return new();
        }
    }
}
