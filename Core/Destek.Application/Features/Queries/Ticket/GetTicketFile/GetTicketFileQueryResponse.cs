using Destek.Application.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Ticket.GetTicketFile
{
    public class GetTicketFileQueryResponse
    {

        public int TotalCount { get; set; }
        public ICollection<TicketFileModelDto> TicketFiles { get; set; }
    }
}
