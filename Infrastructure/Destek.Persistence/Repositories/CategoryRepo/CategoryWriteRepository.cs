using Destek.Application.Repositories.CategoryRepo;
using Destek.Domain.Entities;
using Destek.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Persistence.Repositories.CategoryRepo
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(DestekDbContext context) : base(context)
        {
        }
    }
}
