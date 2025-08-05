using Destek.Application.Repositories.DepartmentRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.DepartmentRepo
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(DestekDbContext context) : base(context)
        {
        }

      
    }
}
