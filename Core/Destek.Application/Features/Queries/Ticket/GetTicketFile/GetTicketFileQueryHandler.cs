using Destek.Application.DTOs.Ticket;
using Destek.Application.Features.Queries.Ticket.GetByIdTicket;
using Destek.Application.Helpers;
using Destek.Application.Repositories.TicketRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Ticket.GetTicketFile
{
    public class GetTicketFileQueryHandler(ITicketReadRepository ticketReadRepository, IConfiguration configuration) : IRequestHandler<GetTicketFileQueryRequest, GetTicketFileQueryResponse>
    {
        public async Task<GetTicketFileQueryResponse> Handle(GetTicketFileQueryRequest request, CancellationToken cancellationToken)
        {
            c.Ticket ticket = await ticketReadRepository.Table.Include(p => p.TicketFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.TicketId));
            var files = ticket.TicketFiles.Select(p => new TicketFileModelDto
            {
                Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
                FileName = p.FileName,
                Extension = Path.GetExtension(p.FileName),
                IsImage = IsImageHelper.FileIsImage(Path.GetExtension(p.FileName)),
            }).ToList();

            return new GetTicketFileQueryResponse
            {
                TicketFiles = files,
                TotalCount = 0
            };
        }
    }
}
