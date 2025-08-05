using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketUnnecessaryRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.TicketUnnecessaryRepo
{
    public class TicketUnnecessaryReadRepository : ReadRepository<TicketUnnecessary>, ITicketUnnecessaryReadRepository
    {
        public TicketUnnecessaryReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
