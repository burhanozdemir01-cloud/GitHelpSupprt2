using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;

namespace Destek.Domain.Entities
{
    public class TicketAssign:BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid AppUserId { get; set; }
        public string Description { get; set; }
        public int JobCount { get; set; } = 1;
        public int ExtraPoint { get; set; } = 0;
        public int TransactionPoint { get; set; } = 0;
        public bool SendSms { get; set; }
        public DateTime? JobStartDate { get; set; }
        public DateTime? JobEndDate { get; set; }
        public Ticket Ticket { get; set; }
        public AppUser AppUser { get; set; }
       
    }
}
