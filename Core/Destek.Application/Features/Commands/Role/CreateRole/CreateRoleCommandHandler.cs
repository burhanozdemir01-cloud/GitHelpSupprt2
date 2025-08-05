using Destek.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandHandler(IRoleService roleService) : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await roleService.CreateRole(request.Name);
            return new()
            {
                Succeeded = result
            };
        }
    }
}
