using Destek.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.TicketLocked.Locked
{
    public class LockedTicketLockedCommandRequest:IRequest<LockedTicketLockedCommandResponse>
    {
        public string TicketId { get; set; }

        public string Note { get; set; }

        public ResolveType ResolveType { get; set; }
    }
}
