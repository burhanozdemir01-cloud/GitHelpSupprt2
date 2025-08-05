using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.TicketUnnecessary.Create
{
    public class CreateTicketUnnecessaryCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
