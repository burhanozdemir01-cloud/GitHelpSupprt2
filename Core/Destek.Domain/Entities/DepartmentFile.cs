using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class DepartmentFile:CommonFile
    {
        public bool Showcase { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}
