using Destek.Application.DTOs.TicketAssign;
using Destek.Application.Repositories.TicketAssignRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Destek.Application.Features.Queries.TicketAssign.GetAllTicketAssign
{
    public class GetAllTicketAssignQueryHandler(ITicketAssignReadRepository ticketAssignReadRepository) : IRequestHandler<GetAllTicketAssignQueryRequest, GetAllTicketAssignQueryResponse>
    {
        public async Task<GetAllTicketAssignQueryResponse> Handle(GetAllTicketAssignQueryRequest request, CancellationToken cancellationToken)
        {
            var query = ticketAssignReadRepository.GetAll(false).Where(x=>x.TicketId==Guid.Parse(request.TicketId) && !x.IsDeleted && x.IsActive).Include(x => x.AppUser);
           
            
            
            var ticketAssigns = query.Select(ticket => new TicketAssignModelDto
            {
                Id = ticket.Id.ToString(),
                UserName = ticket.AppUser.FirstName + " " + ticket.AppUser.LastName,
                Description = ticket.Description,
                JobCount = ticket.JobCount,
                ExtraPoint = ticket.ExtraPoint,
                TransactionPoint = ticket.TransactionPoint,
                SendSms = ticket.SendSms,
                CreateDate = ticket.CreatedDate,
            }).ToList();

            return new GetAllTicketAssignQueryResponse
            {         
                TicketAssigns = ticketAssigns
            };
        }
    }
}
