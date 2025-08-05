using Destek.Application.Repositories.TicketRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketRepo
{
    public class TicketReadRepository : ReadRepository<Ticket>, ITicketReadRepository
    {
        public TicketReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
