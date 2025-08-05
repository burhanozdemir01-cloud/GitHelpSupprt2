using Destek.Application.Repositories;
using Destek.Application.Repositories.TicketRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.TicketRepo
{
    public class TicketWriteRepository : WriteRepository<Ticket>, ITicketWriteRepository
    {
        public TicketWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
