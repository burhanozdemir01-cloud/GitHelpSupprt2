using Destek.Application.DTOs.Catgeory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
