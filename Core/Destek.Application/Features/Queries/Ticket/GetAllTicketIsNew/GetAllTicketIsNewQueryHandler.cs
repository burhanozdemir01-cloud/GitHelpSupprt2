using Destek.Application.DTOs.Ticket;
using Destek.Application.Repositories.TicketRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Ticket.GetAllTicketIsNew
{
    public class GetAllTicketIsNewQueryHandler(ITicketReadRepository ticketReadRepository) : IRequestHandler<GetAllTicketIsNewQueryRequest, GetAllTicketIsNewQueryResponse>
    {
        public async Task<GetAllTicketIsNewQueryResponse> Handle(GetAllTicketIsNewQueryRequest request, CancellationToken cancellationToken)
        {
            var query = ticketReadRepository.GetAll(false).Where(x => x.IsImportand && x.IsLocked==request.IsLocked && x.IsNew==request.IsNew).Include(x => x.SubCategory).Include(x => x.SubCategory.Category).Include(x => x.SubCategory.Category.Department).Include(x => x.AppUser);

            IQueryable<d.Ticket> queryTicket = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryTicket = query.Where(x => (x.Title.Contains(request.Search) || x.CreatedByName.Contains(request.Search) || x.AppUser.FirstName.Contains(request.Search) || x.AppUser.LastName.Contains(request.Search) || x.Department.Name.Contains(request.Search) || x.TraceNumber.Contains(request.Search)));
                totalCount = queryTicket.Count();
            }
            else
            {
                queryTicket = query;
                totalCount = query.Count();

            }      
            var tickets = queryTicket.Skip(request.Size * request.Page).Take(request.Size).Select(ticket => new TicketModelDto
            {
                Id = ticket.Id.ToString(),
                DepartmentName = ticket.Department.Name,
                CategoryName = ticket.SubCategory.Category.Name,
                SubCategoryName = ticket.SubCategory.Name,
                UserName = ticket.AppUser.FirstName + " " + ticket.AppUser.LastName,
                Title = ticket.Title,
                CreateDate = ticket.CreatedDate,
                IsLocked = ticket.IsLocked,
                TraceNumber = ticket.TraceNumber,

            }).ToList();

            return new GetAllTicketIsNewQueryResponse
            {
                TotalCount = totalCount,
                Tickets = tickets
            };
        }
    }
}
