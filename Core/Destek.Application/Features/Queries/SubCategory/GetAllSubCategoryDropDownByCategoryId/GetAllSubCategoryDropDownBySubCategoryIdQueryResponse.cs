using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.SubCategory.GetAllSubCategoryDropDownByCategoryId
{
    public class GetAllSubCategoryDropDownBySubCategoryIdQueryResponse
    {
        public int TotalCount { get; set; }
        public object SubCategories { get; set; }
    }
}
