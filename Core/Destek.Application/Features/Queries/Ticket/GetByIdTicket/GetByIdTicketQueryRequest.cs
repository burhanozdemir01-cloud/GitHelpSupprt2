using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Ticket.GetByIdTicket
{
    public class GetByIdTicketQueryRequest:IRequest<GetByIdTicketQueryResponse>
    {
        public string Id { get; set; }
    }
}
