using Destek.Application.Repositories.ProcessingTimeRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.ProcessingTimeRepo
{
    public class ProcessingTimeReadRepository : ReadRepository<ProcessingTime>, IProcessingTimeReadRepository
    {
        public ProcessingTimeReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
