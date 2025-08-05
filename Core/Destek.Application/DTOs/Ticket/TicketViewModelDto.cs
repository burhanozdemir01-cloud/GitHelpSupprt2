using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.Ticket
{
    public class TicketViewModelDto
    {
        public TicketDetailModelDto Ticket { get; set; }
        public ICollection<TicketFileModelDto> TicketFiles { get; set; }
    }
}
