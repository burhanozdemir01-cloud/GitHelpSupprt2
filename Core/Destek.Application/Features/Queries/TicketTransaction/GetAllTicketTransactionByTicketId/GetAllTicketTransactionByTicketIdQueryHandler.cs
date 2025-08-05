using Destek.Application.DTOs.Ticket;
using Destek.Application.DTOs.TicketTransaction;
using Destek.Application.Features.Queries.Ticket.GetAllTicket;
using Destek.Application.Helpers;
using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Destek.Application.Features.Queries.TicketTransaction.GetAllTicketTransactionByTicketId
{
    public class GetAllTicketTransactionByTicketIdQueryHandler(ITicketTransactionReadRepository ticketTransactionReadRepository, IConfiguration configuration) : IRequestHandler<GetAllTicketTransactionByTicketIdQueryRequest, GetAllTicketTransactionByTicketIdQueryResponse>
    {
        public async Task<GetAllTicketTransactionByTicketIdQueryResponse> Handle(GetAllTicketTransactionByTicketIdQueryRequest request, CancellationToken cancellationToken)
        {

            //TicketTransactionTicketTransactionFile
            var datas = ticketTransactionReadRepository.GetAll(false).Include(x => x.AppUser).Include(x => x.TicketTransactionFiles).Where(x => x.TicketId == Guid.Parse(request.TicketId)).OrderByDescending(x => x.CreatedDate).OrderBy(x => x.CreatedDate).Select(p => new TicketTransactionModelDto
            {
                Id = p.Id.ToString(),
                UserName = p.AppUser.FirstName + " " + p.AppUser.LastName,
                TicketId = p.TicketId.ToString(),
                Description = p.Description,
                CreateDate = p.CreatedDate,
                OperationType = p.OperationType,
                TicketTransactionFiles = p.TicketTransactionFiles.Select(f => new TicketTransactionFileModelDto
                {
                    Path = $"{configuration["BaseStorageUrl"]}/{f.Path}",
                    FileName = f.FileName,
                    Extension = Path.GetExtension(f.FileName),
                    IsImage = IsImageHelper.FileIsImage(Path.GetExtension(f.FileName)),
                }).ToList()
            }).ToList();

            return new GetAllTicketTransactionByTicketIdQueryResponse
            {

                TicketTransactions = datas,
                TotalCount = 0
            };

        }
    }
}
