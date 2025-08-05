using Destek.Application.Repositories.TicketAssignRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.TicketAssignRepo
{
    public class TicketAssignWriteRepository : WriteRepository<TicketAssign>, ITicketAssignWriteRepository
    {
        public TicketAssignWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
