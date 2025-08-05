using Destek.Application.Abstractions.Services;
using Destek.Application.DTOs.User;
using Destek.Application.Repositories.ProcessingTimeRepo;
using Destek.Application.Repositories.TicketTransactionFileRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using MediatR;
using static Google.Apis.Requests.BatchRequest;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.ProcessingTime.Create
{
    public class CreateProcessingTimeCommandHandler(IProcessingTimeWriteRepository processingTimeWriteRepository, IProcessingTimeReadRepository processingTimeReadRepository) : IRequestHandler<CreateProcessingTimeCommandRequest, CreateProcessingTimeCommandResponse>
    {
        public async Task<CreateProcessingTimeCommandResponse> Handle(CreateProcessingTimeCommandRequest request, CancellationToken cancellationToken)
        {
            d.ProcessingTime processingTime = processingTimeReadRepository.GetWhere(x=>x.SubCategoryId==Guid.Parse(request.SubCategoryId) && x.IsActive && !x.IsDeleted).FirstOrDefault();
            if (processingTime != null)
            {
                processingTime.IsActive = false;
                processingTime.IsDeleted = true;
                if (await processingTimeWriteRepository.SaveAsync() == 0)
                {
                    return new()
                    {
                        Message = "Beklenmeyen bir hata oluştu",
                        Succeeded = false,
                    };
                }

            }
           

            await processingTimeWriteRepository.AddAsync(new()
            {
                SubCategoryId = Guid.Parse(request.SubCategoryId),
                Minute = request.Minute,
            });
            if (await processingTimeWriteRepository.SaveAsync() == 1)
            {
                return new()
                {
                    Message = "İşlem başarılı bir şekilde yapıldı.",
                    Succeeded = true,
                };
            }


            return new()
            {
                Message = "Beklenmeyen bir hata oluştu",
                Succeeded = false,
            };
        }
    }
}
