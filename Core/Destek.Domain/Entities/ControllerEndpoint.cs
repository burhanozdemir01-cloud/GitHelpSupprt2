using Destek.Domain.Entities.Common;
using Destek.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class ControllerEndpoint:BaseEntity
    {
        public Guid ControllerMenuId { get; set; }
        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public ControllerMenu ControllerMenu { get; set; }
        public ICollection<AppRole> Roles { get; set; }
    }
}
