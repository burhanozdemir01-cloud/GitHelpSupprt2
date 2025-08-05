using Destek.Application.Abstractions.Services;
using Destek.Application.Repositories.TicketLockedRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Enums;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketLocked.Locked
{
    public class LockedTicketLockedCommandHandler(ITicketLockedWriteRepository ticketLockedWriteRepository,ITicketLockedReadRepository ticketLockedReadRepository,ITicketReadRepository ticketReadRepository, ITicketWriteRepository ticketWriteRepository,ITicketTransactionWriteRepository ticketTransactionWriteRepository,IUserService userService) : IRequestHandler<LockedTicketLockedCommandRequest, LockedTicketLockedCommandResponse>
    {
        public async Task<LockedTicketLockedCommandResponse> Handle(LockedTicketLockedCommandRequest request, CancellationToken cancellationToken)
        {
            var isExist=ticketLockedReadRepository.GetWhere(x=>x.TicketId==Guid.Parse(request.TicketId) && x.IsActive && !x.IsDeleted).FirstOrDefault();
            if(isExist!=null)
            {
                return new()
                {
                    Message = "Bu destek zaten kapatılmış. İşlem yapamazsınız.",
                    Succeeded = false,
                };
            }

            await ticketLockedWriteRepository.AddAsync(new()
            {
                TicketId = Guid.Parse(request.TicketId),
                Note = request.Note,
                ResolveType = request.ResolveType,
            });
            d.Ticket ticket = await ticketReadRepository.GetByIdAsync(request.TicketId);
            if (ticket != null)
            {
                ticket.IsLocked = true;
                var user =await userService.GetCurrentUser();
                await ticketTransactionWriteRepository.AddAsync(new d.TicketTransaction()
                {
                    TicketId= Guid.Parse(request.TicketId),
                    Description="Destek "+ user.FirstName+" "+user.LastName +" tarafından çözüldü olarak sonlandırılmıştır.",
                    OperationType=OperationType.Resolved,
                    AppUserId=user.Id,

                });
                await ticketWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Destek başarılı bir şekilde kapatıldı.",
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
