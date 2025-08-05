using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.ProcessingTime.GetSubCategoryMinute
{
    public class GetSubCategoryMinuteQueryRequest:IRequest<GetSubCategoryMinuteQueryResponse>
    {
        public string SubCategoryId { get; set; }
    }
}
