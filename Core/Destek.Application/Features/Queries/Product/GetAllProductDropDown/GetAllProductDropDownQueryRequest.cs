using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Product.GetAllProductDropDown
{
    public class GetAllProductDropDownQueryRequest:IRequest<GetAllProductDropDownQueryResponse>
    {
        public string DepartmentId { get; set; }
    }
}
