using Destek.Application.Repositories.BrandRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;

namespace Destek.Persistence.Repositories.BrandRepo
{
    public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
    {
        public BrandReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
