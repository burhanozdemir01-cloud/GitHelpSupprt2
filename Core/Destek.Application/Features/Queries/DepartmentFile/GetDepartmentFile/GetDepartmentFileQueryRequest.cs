using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.DepartmentFile.GetDepartmentFile
{
    public class GetDepartmentFileQueryRequest:IRequest<List<GetDepartmentFileQueryResponse>>
    {
        public string Id { get; set; }
    }
}
