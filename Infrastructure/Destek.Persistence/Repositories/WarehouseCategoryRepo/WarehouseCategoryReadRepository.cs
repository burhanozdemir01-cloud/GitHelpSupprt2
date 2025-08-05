using Destek.Application.Repositories.WarehouseCategoryRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseCategoryRepo
{
    public class WarehouseCategoryReadRepository : ReadRepository<WarehouseCategory>, IWarehouseCategoryReadRepository
    {
        public WarehouseCategoryReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
