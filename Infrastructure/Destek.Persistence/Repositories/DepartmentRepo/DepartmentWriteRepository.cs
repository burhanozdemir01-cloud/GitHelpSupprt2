using Destek.Application.Repositories.DepartmentRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.DepartmentRepo
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
