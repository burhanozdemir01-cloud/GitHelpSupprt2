using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryResponse
    {
        public object Roles { get; set; }
        public int TotalCount { get; set; }
    }
}
