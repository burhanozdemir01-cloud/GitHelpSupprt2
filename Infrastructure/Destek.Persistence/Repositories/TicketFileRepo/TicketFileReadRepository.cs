using Destek.Application.Repositories.TicketFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.TicketFileRepo
{
    public class TicketFileReadRepository : ReadRepository<TicketFile>, ITicketFileReadRepository
    {
        public TicketFileReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
