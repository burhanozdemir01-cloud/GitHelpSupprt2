using Destek.Application.DTOs.TicketTransaction;
using Destek.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.DTOs.Ticket
{
    public class TicketModelDto
    {
        public string Id { get; set; }
        public string DepartmentName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }

        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool IsLocked { get; set; }
        public string TraceNumber { get; set; }
       

    }
}
