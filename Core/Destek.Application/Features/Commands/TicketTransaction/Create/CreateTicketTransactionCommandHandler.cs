using Destek.Application.Abstractions.Services;
using Destek.Application.Abstractions.Storage;
using Destek.Application.Repositories.TicketTransactionFileRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Entities;
using Destek.Domain.Enums;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.TicketTransaction.Create
{
    public class CreateTicketTransactionCommandHandler(ITicketTransactionWriteRepository ticketTransactionWriteRepository, ITicketTransactionReadRepository ticketTransactionReadRepository, IUserService userService, IStorageService storageService, ITicketTransactionFileWriteRepository ticketTransactionFileWriteRepository) : IRequestHandler<CreateTicketTransactionCommandRequest, CreateTicketTransactionCommandResponse>
    {
        public async Task<CreateTicketTransactionCommandResponse> Handle(CreateTicketTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            Guid newId = Guid.NewGuid();
            bool isExistFile = false;
            if (request.Files!=null)
            {
                isExistFile = true;
            }

            var addControl = await ticketTransactionWriteRepository.AddAsync(new()
            {
                Id = newId,
                TicketId = Guid.Parse(request.TicketId),
                AppUserId = userService.GetCurrentUser().Result.Id,
                Description = request.Description,
                OperationType = Domain.Enums.OperationType.Answered

            });
            if (addControl)
            {
                if (await ticketTransactionWriteRepository.SaveAsync() == 1)
                {
                    if (isExistFile)
                    {
                        var fileEntries = new List<TicketTransactionFile>();
                        List<(string fileName, string pathOrContainerName)> result = await storageService.UploadAsync("photo-images", request.Files);
                        d.TicketTransaction ticketTransaction = await ticketTransactionReadRepository.GetByIdAsync(newId.ToString());
                        foreach (var file in result)
                        {
                            var fileEntry = new TicketTransactionFile
                            {
                                FileName = file.fileName,
                                Path = file.pathOrContainerName,
                                StorageType = StorageType.Local,
                                CreatedDate = DateTime.Now,
                                TicketTransactions = new List<d.TicketTransaction> { ticketTransaction }
                            };
                            fileEntries.Add(fileEntry);
                        }
                        await ticketTransactionFileWriteRepository.AddRangeAsync(fileEntries);
                        await ticketTransactionFileWriteRepository.SaveAsync();
                    }
                    return new()
                    {
                        Message = "Cevabınız gönderildi",
                        Succeeded = true,
                    };

                }


            }


            return new()
            {
                Message = "Beklenmeyen bir hata oluştu. İşlem başarısız oldu.",
                Succeeded = false,
            };

        }
    }
}
