using Destek.Application.Repositories.TicketTransactionFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketTransactionFileRepo
{
    public class TicketTransactionFileReadRepository : ReadRepository<TicketTransactionFile>, ITicketTransactionFileReadRepository
    {
        public TicketTransactionFileReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
