using Destek.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.TicketTransaction
{
    public class TicketTransactionModelDto
    {
        public string Id { get; set; }
        public string TicketId { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
       public OperationType OperationType { get; set; }
        public ICollection<TicketTransactionFileModelDto> TicketTransactionFiles { get; set; }
    }
}
