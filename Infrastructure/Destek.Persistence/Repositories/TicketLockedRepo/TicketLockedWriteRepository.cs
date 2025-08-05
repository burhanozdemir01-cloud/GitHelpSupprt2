using Destek.Application.Repositories.TicketLockedRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketLockedRepo
{
    public class TicketLockedWriteRepository : WriteRepository<TicketLocked>, ITicketLockedWriteRepository
    {
        public TicketLockedWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
