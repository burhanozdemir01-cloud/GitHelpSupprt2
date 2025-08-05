using Destek.Application.DTOs.Ticket;
using Destek.Application.Repositories.TicketRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Ticket.GetAllTicket
{
    public class GetAllTicketQueryHandler(ITicketReadRepository ticketReadRepository) : IRequestHandler<GetAllTicketQueryRequest, GetAllTicketQueryResponse>
    {
        public async Task<GetAllTicketQueryResponse> Handle(GetAllTicketQueryRequest request, CancellationToken cancellationToken)
        {
            var query = ticketReadRepository.GetAll(false).Where(x=>x.IsImportand && !x.IsLocked).Include(x => x.SubCategory).Include(x => x.SubCategory.Category).Include(x => x.SubCategory.Category.Department).Include(x=>x.AppUser);
           
            IQueryable<d.Ticket> queryTicket = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {
              
                queryTicket = query.Where(x =>(x.Title.Contains(request.Search) || x.CreatedByName.Contains(request.Search) || x.AppUser.FirstName.Contains(request.Search) || x.AppUser.LastName.Contains(request.Search) || x.Department.Name.Contains(request.Search) || x.TraceNumber.Contains(request.Search)));
                totalCount= queryTicket.Count();
            }
            else
            {
                queryTicket = query;
                totalCount = query.Count();

            }
            // var datas = queryTicket.Skip(request.Size * request.Page).Take(request.Size);
            //var datas = queryTicket.Skip(request.Size * request.Page).Include(x => x.SubCategory).Include(x=>x.SubCategory.Category).Include(x=>x.SubCategory.Category.Department).Take(request.Size).Select(p => new
            //{
            //    p.Id,
            //    p.Title,
            //    p.Detail,
            //    p.IsActive,
            //    p.CreatedDate,
            //    p.TraceNumber,
            //    p.SubCategory.Category.Department,


            //}).ToList();
            var tickets = queryTicket.Skip(request.Size * request.Page).Take(request.Size).Select(ticket => new TicketModelDto
            {
                Id = ticket.Id.ToString(),
                DepartmentName = ticket.Department.Name,
                CategoryName = ticket.SubCategory.Category.Name,
                SubCategoryName = ticket.SubCategory.Name,
                UserName = ticket.AppUser.FirstName + " " + ticket.AppUser.LastName,
                Title = ticket.Title,
                CreateDate = ticket.CreatedDate,
                TraceNumber = ticket.TraceNumber,
              
            }).ToList();

            return new GetAllTicketQueryResponse
            {
                TotalCount = totalCount,
                Tickets = tickets
            };

        }
    }
}
