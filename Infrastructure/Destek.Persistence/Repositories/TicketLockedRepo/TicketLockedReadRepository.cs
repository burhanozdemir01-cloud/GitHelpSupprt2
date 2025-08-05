using Destek.Application.Repositories.TicketLockedRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketLockedRepo
{
    public class TicketLockedReadRepository : ReadRepository<TicketLocked>, ITicketLockedReadRepository
    {
        public TicketLockedReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
