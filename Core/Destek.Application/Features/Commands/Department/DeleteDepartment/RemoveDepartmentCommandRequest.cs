using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Department.DeleteDepartment
{
    public class RemoveDepartmentCommandRequest:IRequest<RemoveDepartmentCommandResponse>
    {
        public string Id { get; set; }
    }
}
