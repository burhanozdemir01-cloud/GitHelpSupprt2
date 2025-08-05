using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.TicketAssign.CreateTicketAssign
{
    public class CreateTicketAssignCommandRequest:IRequest<CreateTicketAssignCommandResponse>
    {
        public string TicketId { get; set; }
        public string AppUserId { get; set; }
        public string Description { get; set; }
        public int JobCount { get; set; }
        public int ExtraPoint { get; set; }
        public bool SendSms { get; set; }
    }
}
