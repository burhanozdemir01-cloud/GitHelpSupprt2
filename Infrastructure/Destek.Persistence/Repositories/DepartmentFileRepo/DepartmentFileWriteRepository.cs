using Destek.Application.Repositories.DepartmentFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.DepartmentFileRepo
{
    public class DepartmentFileWriteRepository : WriteRepository<DepartmentFile>, IDepartmentFileWriteRepository
    {
        public DepartmentFileWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
