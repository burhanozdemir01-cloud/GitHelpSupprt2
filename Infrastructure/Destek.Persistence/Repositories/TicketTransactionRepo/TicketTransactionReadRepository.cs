using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketTransactionRepo
{
    public class TicketTransactionReadRepository : ReadRepository<TicketTransaction>, ITicketTransactionReadRepository
    {
        public TicketTransactionReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
