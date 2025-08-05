using Destek.Application.Abstractions.Services;
using Destek.Application.Abstractions.Storage;
using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.TicketFileRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.TicketTransactionFileRepo;
using Destek.Application.Repositories.TicketTransactionRepo;
using Destek.Domain.Entities;
using Destek.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Ticket.CreateTicket
{
    public class CreateTicketCommandHandler(ITicketWriteRepository ticketWriteRepository, ITicketReadRepository ticketReadRepository, IUserService userService, IStorageService storageService, ITicketFileWriteRepository ticketFileWriteRepository) : IRequestHandler<CreateTicketCommandRequest, CreateTicketCommandResponse>
    {
        public async Task<CreateTicketCommandResponse> Handle(CreateTicketCommandRequest request, CancellationToken cancellationToken)
        {

            var appUser = userService.GetCurrentUser();
            Guid newId = Guid.NewGuid();
            string traceNumber = Guid.NewGuid().ToString();
            bool isExistFile = false;
            if (request.Files!=null)
            {
                isExistFile = true;
            }
            var addControl = await ticketWriteRepository.AddAsync(new()
            {
                Id = newId,
                Title = request.Title,
                SubCategoryId = Guid.Parse(request.SubCategoryId),
                Detail = request.Detail,
                IsNew = true,
                IsImportand = true,
                ImportanceLevel = request.ImportanceLevel,
                TraceNumber = traceNumber,
                DepartmentId = Guid.Parse(request.DepartmentId),
                NormalizedTraceNumber = traceNumber.ToUpper(),
                AppUserId = appUser.Result.Id,
                IsLocked = false,

            });
            if (addControl)
            {
                if (await ticketWriteRepository.SaveAsync() == 1)
                {
                    if (isExistFile)
                    {
                        var fileEntries = new List<TicketFile>();
                        List<(string fileName, string pathOrContainerName)> result = await storageService.UploadAsync("photo-images", request.Files);
                        d.Ticket ticket = await ticketReadRepository.GetByIdAsync(newId.ToString());
                        foreach (var file in result)
                        {
                            var fileEntry = new TicketFile
                            {
                                FileName = file.fileName,
                                Path = file.pathOrContainerName,
                                StorageType = StorageType.Local,
                                CreatedDate = DateTime.Now,
                                Tickets = new List<d.Ticket> { ticket }
                            };
                            fileEntries.Add(fileEntry);
                        }
                        await ticketFileWriteRepository.AddRangeAsync(fileEntries);
                        await ticketFileWriteRepository.SaveAsync();
                    }
                    return new()
                    {
                        Message = "Talebiniz gönderildi",
                        Succeeded = true,
                    };

                }


            }
            //var userName = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;

            //await ticketWriteRepository.AddAsync(new()
            //{
            //    Title = request.Title,
            //    SubCategoryId = Guid.Parse(request.SubCategoryId),
            //    Detail = request.Detail,
            //    IsNew = true,
            //    IsImportand = true,
            //    ImportanceLevel = request.ImportanceLevel,
            //    TraceNumber = traceNumber,
            //    DepartmentId = Guid.Parse(request.DepartmentId),
            //    NormalizedTraceNumber = traceNumber.ToUpper(),
            //    AppUserId= appUser.Result.Id,
            //    IsLocked = false,
            //    //CreatedByName= appUser.Result.UserName,
            //    //ModifiedByName = appUser.Result.UserName,
            //}) ;
            //await ticketWriteRepository.SaveAsync();
            //return new();

            return new()
            {
                Message = "Beklenmeyen bir hata oluştu. İşlem başarısız oldu.",
                Succeeded = false,
            };
        }
    }
}
