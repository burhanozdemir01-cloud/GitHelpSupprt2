using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Brand.GetAllBrandDropDown
{
    public class GetAllBrandDropDownQueryRequest:IRequest<GetAllBrandDropDownQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
