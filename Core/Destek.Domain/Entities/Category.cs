using Destek.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class Category:BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }

        public Department Department { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }

    }
}
