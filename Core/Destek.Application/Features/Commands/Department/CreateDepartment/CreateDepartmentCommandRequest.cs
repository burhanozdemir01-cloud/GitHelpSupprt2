using Destek.Application.DTOs.Catgeory;
using Destek.Application.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Department.CreateDepartment
{
    public class CreateDepartmentCommandRequest:IRequest<CreateDepartmentCommandResponse>
    {
        //public DepartmentAddDto DepartmentAddDto { get; set; }
        public string Name { get; set; }
        public string? FullName { get; set; }
        public bool IsPublish { get; set; }
    }
}
