using Destek.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Domain.Entities
{
    public class SubCategory:BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int SequenceNumber { get; set; }

        public Category Category { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<ProcessingTime> ProcessingTimes { get; set; }
    }
}
