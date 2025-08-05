using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Ticket.GetTicketFile
{
    public class GetTicketFileQueryRequest:IRequest<GetTicketFileQueryResponse>
    {
        public string TicketId { get; set; }
    }
}
