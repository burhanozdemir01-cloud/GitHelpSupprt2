using Destek.Application.Repositories.WarehouseCategoryRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseCategoryRepo
{
    public class WarehouseCategoryWriteRepository : WriteRepository<WarehouseCategory>, IWarehouseCategoryWriteRepository
    {
        public WarehouseCategoryWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
