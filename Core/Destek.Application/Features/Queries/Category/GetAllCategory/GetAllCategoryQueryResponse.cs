using Destek.Application.DTOs.Catgeory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public int TotalCount { get; set; }

        public object Categories { get; set; }

        //public CategoryListDto? CategoryListDto { get; set; }
    }
}
