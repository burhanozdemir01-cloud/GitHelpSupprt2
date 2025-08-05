using Destek.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsPublish { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<DepartmentFile> DepartmentFiles { get; set; }
        
        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<WarehouseCategory> WarehouseCategories { get; set; }

        public ICollection<Brand> Brands { get; set; }

    }
}
