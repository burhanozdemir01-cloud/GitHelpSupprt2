using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketTransactionRepo
{
    public class TicketTransactionWriteRepository : WriteRepository<TicketTransaction>, ITicketTransactionWriteRepository
    {
        public TicketTransactionWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
