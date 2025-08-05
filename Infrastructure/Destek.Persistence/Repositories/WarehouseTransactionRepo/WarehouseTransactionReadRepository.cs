using Destek.Application.Repositories.WarehouseTransactionRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseTransactionRepo
{
    public class WarehouseTransactionReadRepository : ReadRepository<WarehouseTransaction>, IWarehouseTransactionReadRepository
    {
        public WarehouseTransactionReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
