using Destek.Application.Repositories.BrandRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.BrandRepo
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
