using Destek.Application.Repositories.ProcessingTimeRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.ProcessingTimeRepo
{
    public class ProcessingTimeWriteRepository : WriteRepository<ProcessingTime>, IProcessingTimeWriteRepository
    {
        public ProcessingTimeWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
