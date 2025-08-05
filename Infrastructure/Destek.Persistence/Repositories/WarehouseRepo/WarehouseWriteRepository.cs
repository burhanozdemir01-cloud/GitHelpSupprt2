using Destek.Application.Repositories.WarehouseRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseRepo
{
    public class WarehouseWriteRepository : WriteRepository<Warehouse>, IWarehouseWriteRepository
    {
        public WarehouseWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
