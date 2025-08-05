using Destek.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class ControllerMenu:BaseEntity
    {
        public Guid Name { get; set; }
        public ICollection<ControllerEndpoint> ControllerEndpoints { get; set; }
    }
}
