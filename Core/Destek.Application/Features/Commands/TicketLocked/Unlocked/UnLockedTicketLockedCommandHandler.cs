using Destek.Application.Abstractions.Services;
using Destek.Application.Repositories.TicketLockedRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Enums;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketLocked.Unlocked
{
    public class UnLockedTicketLockedCommandHandler (ITicketLockedWriteRepository ticketLockedWriteRepository, ITicketLockedReadRepository ticketLockedReadRepository, ITicketReadRepository ticketReadRepository, ITicketWriteRepository ticketWriteRepository, ITicketTransactionWriteRepository ticketTransactionWriteRepository, IUserService userService) : IRequestHandler<UnLockedTicketLockedCommandRequest, UnLockedTicketLockedCommandResponse>
    {
        public async Task<UnLockedTicketLockedCommandResponse> Handle(UnLockedTicketLockedCommandRequest request, CancellationToken cancellationToken)
        {
            d.TicketLocked ticketLocked = ticketLockedReadRepository.GetWhere(x => x.TicketId == Guid.Parse(request.TicketId) && x.IsActive && !x.IsDeleted).FirstOrDefault();
            if (ticketLocked == null)
            {
                return new()
                {
                    Message = "Bu destek zaten kapatılmış. İşlem yapamazsınız.",
                    Succeeded = false,
                };
            }
            ticketLocked.IsActive = false;
          
           
            await ticketLockedWriteRepository.AddAsync(new()
            {
                TicketId = Guid.Parse(request.TicketId),
                Note = request.Note,
                ResolveType = request.ResolveType,
                IsActive=false,
            });
            d.Ticket ticket = await ticketReadRepository.GetByIdAsync(request.TicketId);
            if (ticket != null)
            {
                ticket.IsLocked = false;
                var user = await userService.GetCurrentUser();
                await ticketTransactionWriteRepository.AddAsync(new d.TicketTransaction()
                {
                    TicketId = Guid.Parse(request.TicketId),
                    Description =$"Destek {user.FirstName} {user.LastName} tarafından tekrar açıldı. {request.Note}",
                    OperationType = OperationType.Opened,
                    AppUserId = user.Id,

                });
                await ticketWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Destek tekrar açıldı.",
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
