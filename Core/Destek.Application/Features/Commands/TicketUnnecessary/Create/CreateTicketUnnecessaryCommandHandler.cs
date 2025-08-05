using Destek.Application.Repositories.TicketAssignRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketUnnecessaryRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketUnnecessary.Create
{
    public class CreateTicketUnnecessaryCommandHandler(ITicketUnnecessaryReadRepository ticketUnnecessaryReadRepository, ITicketUnnecessaryWriteRepository ticketUnnecessaryWriteRepository, ITicketReadRepository ticketReadRepository, ITicketWriteRepository ticketWriteRepository, ITicketAssignReadRepository ticketAssignReadRepository) : IRequestHandler<CreateTicketUnnecessaryCommandRequest, CreateTicketUnnecessaryCommandResponse>
    {
        public async Task<CreateTicketUnnecessaryCommandResponse> Handle(CreateTicketUnnecessaryCommandRequest request, CancellationToken cancellationToken)
        {
            var isAssigment = ticketAssignReadRepository.GetWhere(x => x.IsActive && !x.IsDeleted && x.TicketId == Guid.Parse(request.TicketId)).FirstOrDefault();
            if (isAssigment != null)
            {
                return new()
                {
                    Message = "Atanan destek iade edilemez. Önce atamaları iptal ediniz.",
                    Succeeded = false,
                };
            }
            await ticketUnnecessaryWriteRepository.AddAsync(new()
            {
                TicketId = Guid.Parse(request.TicketId),
                Note = request.Note,
            });

            d.Ticket ticket = await ticketReadRepository.GetByIdAsync(request.TicketId);
            if (ticket != null)
            {
                ticket.IsImportand = false;
                await ticketWriteRepository.SaveAsync();
                //  await ticketAssignWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Destek İade Edildi.",
                    Succeeded = true,
                };
            }

            return new()
            {
                Message = "Hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                Succeeded = false,
            };
        }
    }
}
