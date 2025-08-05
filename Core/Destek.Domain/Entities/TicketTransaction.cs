using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;
using Destek.Domain.Enums;

namespace Destek.Domain.Entities
{
    public class TicketTransaction:BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid AppUserId { get; set; }
        public string Description { get; set; }
        public OperationType OperationType { get; set; }
        public AppUser AppUser { get; set; }
        public Ticket Ticket { get; set; }
        public ICollection<TicketTransactionFile> TicketTransactionFiles { get; set; }

    }
}
