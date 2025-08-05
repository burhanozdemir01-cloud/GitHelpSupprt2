using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.ProcessingTime.GetBySubCategoryId
{
    public class GetProcessingTimeBySubCategoryIdQueryResponse
    {
        public Guid Id { get; set; }
        public Guid SubCategoryId { get; set; }
        public int Minute { get; set; }
    }
}
