using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Category.GetAllCategoryDropDownByDepartmentId
{
    public class GetAllCategoryDropDownByDepartmentIdQueryRequest:IRequest<GetAllCategoryDropDownByDepartmentIdQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
