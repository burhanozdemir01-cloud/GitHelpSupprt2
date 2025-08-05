using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.Warehouse
{
    public class WarehouseGetModelDto
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
