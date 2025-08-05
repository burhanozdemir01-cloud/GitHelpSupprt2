using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Department.GetByIdDepartment
{
    public class GetByIdDepartmentQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsPublish { get; set; }
        public bool IsActive { get; set; }
    }
}
