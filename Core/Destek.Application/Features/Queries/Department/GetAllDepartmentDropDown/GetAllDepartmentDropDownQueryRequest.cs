using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Department.GetAllDepartmentDropDown
{
    public class GetAllDepartmentDropDownQueryRequest:IRequest<GetAllDepartmentDropDownQueryResponse>
    {
        public bool IsPublish { get; set; }
    }
}
