using Destek.Application.Abstractions.Services;
using Destek.Application.Repositories.ProcessingTimeRepo;
using Destek.Application.Repositories.TicketAssignRepo;
using Destek.Application.Repositories.TicketRepo;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketAssign.CreateTicketAssign
{
    public class CreateTicketAssignCommandHandler(ITicketAssignWriteRepository ticketAssignWriteRepository, ITicketAssignReadRepository ticketAssignReadRepository,IUserService userService,ITicketReadRepository ticketReadRepository,ITicketWriteRepository ticketWriteRepository,IProcessingTimeReadRepository processingTimeReadRepository) : IRequestHandler<CreateTicketAssignCommandRequest, CreateTicketAssignCommandResponse>
    {
        public async Task<CreateTicketAssignCommandResponse> Handle(CreateTicketAssignCommandRequest request, CancellationToken cancellationToken)
        {
            //var appUser = userService.GetCurrentUser();

            //var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
            // string traceNumber = Guid.NewGuid().ToString();
            int point = 0;
            var isExistAppUser = await ticketAssignReadRepository.GetSingleAsync(x => x.AppUserId == Guid.Parse(request.AppUserId) && x.TicketId == Guid.Parse(request.TicketId) && !x.IsDeleted && x.IsActive);
            if (isExistAppUser != null)
            {
                var user=userService.GetUserInfo(request.AppUserId);
                return new()
                {
                    Message = user.Result.FirstName+" "+user.Result.LastName+" kullanıcısına bu destek daha önce atanmış. Tekrar atama yapamazsınız.",
                    Succeeded = false,
                };
             

            }
            d.Ticket ticket = await ticketReadRepository.GetByIdAsync(request.TicketId);
            if (ticket == null)
            {
                return new()
                {
                    Message = "Destek numarası bulunamadı.",
                    Succeeded = false,
                };
            }
            var processingPoint = processingTimeReadRepository.GetWhere(x => x.SubCategoryId == ticket.SubCategoryId, false).FirstOrDefault();
            if(processingPoint!=null)
            {
                if(processingPoint.Minute>0)
                {
                    point=processingPoint.Minute;
                }
            }
            await ticketAssignWriteRepository.AddAsync(new()
            {
                TicketId = Guid.Parse(request.TicketId),
                AppUserId = Guid.Parse(request.AppUserId),
                Description = request.Description,
                JobCount = request.JobCount,
                ExtraPoint = request.ExtraPoint,
                SendSms = request.SendSms,
                TransactionPoint=point,
            });

           
            if (ticket != null)
            {
                ticket.IsNew = false;
                await ticketWriteRepository.SaveAsync();
              //  await ticketAssignWriteRepository.SaveAsync();

                return new()
                {
                    Message = "Kayıt İşlemi Başarılı",
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
