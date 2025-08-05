using Destek.Application.Features.Queries.Ticket.GetAllTicket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.TicketAssign.GetAllTicketAssign
{
    public class GetAllTicketAssignQueryRequest : IRequest<GetAllTicketAssignQueryResponse>
    {
        public string TicketId { get; set; }
    }
}
