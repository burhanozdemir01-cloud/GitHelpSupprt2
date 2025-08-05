using Destek.Application.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Ticket.GetAllTicket
{
    public class GetAllTicketQueryResponse
    {
        public int TotalCount { get; set; }

        public List<TicketModelDto> Tickets { get; set; }
    }
}
