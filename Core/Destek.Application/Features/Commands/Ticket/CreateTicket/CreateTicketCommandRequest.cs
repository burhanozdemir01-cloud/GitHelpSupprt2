using Destek.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Ticket.CreateTicket
{
    public class CreateTicketCommandRequest:IRequest<CreateTicketCommandResponse>
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string SubCategoryId { get; set; }
        public string DepartmentId { get; set; }
        public ImportanceLevel ImportanceLevel { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
