using Destek.Application.Repositories.WarehouseRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseRepo
{
    public class WarehouseReadRepository : ReadRepository<Warehouse>, IWarehouseReadRepository
    {
        public WarehouseReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
