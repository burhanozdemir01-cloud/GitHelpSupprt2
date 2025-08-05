using Destek.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.TicketLocked.Locked
{
    public class LockedTicketLockedCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        
    }
}
