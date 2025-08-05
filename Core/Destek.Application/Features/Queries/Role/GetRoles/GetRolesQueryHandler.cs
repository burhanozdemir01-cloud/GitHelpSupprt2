using Destek.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryHandler(IRoleService roleService) : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
    {
        public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var (datas, count) = roleService.GetAllRoles(request.Page, request.Size);
            return new()
            {
                Roles = datas,
                TotalCount = count
            };
        }
    }
}
