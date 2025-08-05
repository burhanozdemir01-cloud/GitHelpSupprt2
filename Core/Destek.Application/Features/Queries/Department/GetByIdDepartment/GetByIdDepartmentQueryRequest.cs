using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Department.GetByIdDepartment
{
    public class GetByIdDepartmentQueryRequest:IRequest<GetByIdDepartmentQueryResponse>
    {
        public string Id { get; set; }
    }
}
