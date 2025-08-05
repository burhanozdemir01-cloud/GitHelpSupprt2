using Destek.Application.Repositories.DepartmentRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Department.DeleteDepartment
{
    public class RemoveDepartmentCommandHandler(IDepartmentWriteRepository productWriteRepository) : IRequestHandler<RemoveDepartmentCommandRequest, RemoveDepartmentCommandResponse>
    {
        public async Task<RemoveDepartmentCommandResponse> Handle(RemoveDepartmentCommandRequest request, CancellationToken cancellationToken)
        {
            await productWriteRepository.RemoveAsync(request.Id);
            await productWriteRepository.SaveAsync();
            return new();
        }
    }
}
