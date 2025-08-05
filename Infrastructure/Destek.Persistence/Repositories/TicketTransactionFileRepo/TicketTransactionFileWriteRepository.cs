using Destek.Application.Repositories.TicketTransactionFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketTransactionFileRepo
{
    public class TicketTransactionFileWriteRepository : WriteRepository<TicketTransactionFile>, ITicketTransactionFileWriteRepository
    {
        public TicketTransactionFileWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
