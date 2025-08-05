using Destek.Application.Repositories.DepartmentFileRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.DepartmentFileRepo
{
    public class DepartmentFileReadRepository : ReadRepository<DepartmentFile>, IDepartmentFileReadRepository
    {
        public DepartmentFileReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
