using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Category.GetAllCategoryDropDownByDepartmentId
{
    public class GetAllCategoryDropDownByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }
        public object Categories { get; set; }
    }
}
