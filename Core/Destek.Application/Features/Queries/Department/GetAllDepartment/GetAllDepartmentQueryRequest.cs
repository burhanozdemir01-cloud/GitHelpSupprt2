using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Department.GetAllDepartment
{
    public class GetAllDepartmentQueryRequest:IRequest<GetAllDepartmentQueryResponse>
    {
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
