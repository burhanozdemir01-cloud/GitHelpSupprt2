using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.SubCategory.GetByIdSubCategory
{
    public class GetByIdSubCategoryQueryResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
