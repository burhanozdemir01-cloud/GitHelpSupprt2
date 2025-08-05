using Destek.Application.Repositories.TicketFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketFileRepo
{
    public class TicketFileWriteRepository : WriteRepository<TicketFile>, ITicketFileWriteRepository
    {
        public TicketFileWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
