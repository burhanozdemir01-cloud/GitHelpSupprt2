using Destek.Application.Repositories.WarehouseTransactionRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.WarehouseTransactionRepo
{
    public class WarehouseTransactionWriteRepository : WriteRepository<WarehouseTransaction>, IWarehouseTransactionWriteRepository
    {
        public WarehouseTransactionWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
