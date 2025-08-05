using Microsoft.AspNetCore.Identity;

namespace Destek.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TCKN { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketAssign> TicketAssigns { get; set; }
        public ICollection<TicketTransaction> TicketTransactions { get; set; }
    }
}
