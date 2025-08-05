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
    public class SubCategoryWriteRepository : WriteRepository<SubCategory>, ISubCategoryWriteRepository
    {
        public SubCategoryWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
