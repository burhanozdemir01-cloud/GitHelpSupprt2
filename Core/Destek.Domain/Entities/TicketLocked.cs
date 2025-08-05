using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;
using Destek.Domain.Enums;

namespace Destek.Domain.Entities
{
    public class TicketLocked:BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public ResolveType ResolveType { get; set; }
    }
}
