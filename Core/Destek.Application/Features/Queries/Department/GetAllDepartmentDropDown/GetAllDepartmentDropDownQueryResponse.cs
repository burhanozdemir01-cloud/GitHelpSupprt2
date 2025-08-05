using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Department.GetAllDepartmentDropDown
{
    public class GetAllDepartmentDropDownQueryResponse
    {
        public int TotalCount { get; set; }
        public object Departments { get; set; }
    }
}
