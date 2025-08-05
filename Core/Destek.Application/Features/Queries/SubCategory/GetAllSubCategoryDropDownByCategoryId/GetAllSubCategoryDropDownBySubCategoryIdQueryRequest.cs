using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.SubCategory.GetAllSubCategoryDropDownByCategoryId
{
    public class GetAllSubCategoryDropDownBySubCategoryIdQueryRequest:IRequest<GetAllSubCategoryDropDownBySubCategoryIdQueryResponse>
    {
        public string CategoryId { get; set; }
    }
}
