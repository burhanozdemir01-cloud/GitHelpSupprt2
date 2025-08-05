using Destek.Application.Abstractions.Services;
using Destek.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.AppUser.GetAllUserDropDown
{
    public class GetAllUserDropDownQueryHandler(IUserService userService) : IRequestHandler<GetAllUserDropDownQueryRequest, GetAllUserDropDownQueryResponse>
    {
        public async Task<GetAllUserDropDownQueryResponse> Handle(GetAllUserDropDownQueryRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                Users =await userService.GetAllUsers(),
            };
        }
    }
}
