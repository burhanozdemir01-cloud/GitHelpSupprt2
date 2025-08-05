using Destek.Application.DTOs.Ticket;
using Destek.Application.DTOs.TicketAssign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.TicketAssign.GetAllTicketAssign
{
    public class GetAllTicketAssignQueryResponse
    {
        public List<TicketAssignModelDto> TicketAssigns { get; set; }
    }
}
