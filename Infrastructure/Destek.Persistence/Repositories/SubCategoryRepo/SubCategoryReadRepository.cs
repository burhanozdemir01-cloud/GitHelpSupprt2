using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.SubCategoryRepo
{
    public class SubCategoryReadRepository : ReadRepository<SubCategory>, ISubCategoryReadRepository
    {
        public SubCategoryReadRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
