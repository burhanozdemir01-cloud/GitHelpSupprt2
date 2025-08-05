using Destek.Application.Exceptions;
using Destek.Application.Repositories.TicketAssignRepo;
using Destek.Application.Repositories.TicketRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketAssign.DeleteTicketAssign
{
    public class RemoveTicketAssignCommandHandler(ITicketAssignWriteRepository ticketAssignWriteRepository, ITicketAssignReadRepository ticketAssignReadRepository, ITicketReadRepository ticketReadRepository, ITicketWriteRepository ticketWriteRepository) : IRequestHandler<RemoveTicketAssignCommandRequest, RemoveTicketAssignCommandResponse>
    {
        public async Task<RemoveTicketAssignCommandResponse> Handle(RemoveTicketAssignCommandRequest request, CancellationToken cancellationToken)
        {
            bool atamaUpdateKontrol = false;
            d.TicketAssign ticketAssign = await ticketAssignReadRepository.GetByIdAsync(request.Id);
            ticketAssign.IsDeleted = true;
            ticketAssign.IsActive = false;
            if (await ticketAssignWriteRepository.SaveAsync() == 1)
                atamaUpdateKontrol = true;
            var ticketAssignCount = ticketAssignReadRepository.GetWhere(x => x.IsActive && !x.IsDeleted && x.TicketId== ticketAssign.TicketId).Count();
            if (ticketAssignCount == 0)
            {
                d.Ticket ticket = await ticketReadRepository.GetByIdAsync(ticketAssign.TicketId.ToString());
                if (ticket != null)
                {
                    ticket.IsNew = true;
                    if (await ticketWriteRepository.SaveAsync() == 1)
                        return new();
                    else
                        throw new CommonException("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin");
                }
                throw new CommonException("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin");
            }
            if (atamaUpdateKontrol)
                return new();
            throw new CommonException("Beklenmedik bir hata oluştu. Lütfen daha sonra tekrar deneyin");

        }
    }
}
