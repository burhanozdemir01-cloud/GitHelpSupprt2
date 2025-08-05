using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.TicketAssign
{
    public class TicketAssignModelDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public int JobCount { get; set; }
        public int ExtraPoint { get; set; }
        public int TransactionPoint { get; set; }
        public bool SendSms { get; set; }
        public DateTime? CreateDate { get; set; }
   
    }
}
