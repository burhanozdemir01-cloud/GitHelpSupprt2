using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class TicketFile:CommonFile
    {

        public ICollection<Ticket> Tickets { get; set; }

    }
}
