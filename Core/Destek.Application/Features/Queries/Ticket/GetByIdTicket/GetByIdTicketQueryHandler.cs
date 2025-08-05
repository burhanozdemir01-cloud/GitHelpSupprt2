using Destek.Application.Repositories.TicketRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.Ticket.GetByIdTicket
{
    public class GetByIdTicketQueryHandler(ITicketReadRepository ticketReadRepository, IConfiguration configuration) : IRequestHandler<GetByIdTicketQueryRequest, GetByIdTicketQueryResponse>
    {
        public async Task<GetByIdTicketQueryResponse> Handle(GetByIdTicketQueryRequest request, CancellationToken cancellationToken)
        {

            c.Ticket ticket = await ticketReadRepository.Table.Include(p => p.AppUser).Include(x => x.Department).Include(x => x.SubCategory.Category).Include(x => x.SubCategory).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            return new()
            {
                Id = ticket.Id.ToString(),
                DepartmentName = ticket.Department.Name,
                CategoryName = ticket.SubCategory.Category.Name,
                SubCategoryName=ticket.SubCategory.Name,
                UserName = $"{ticket.AppUser.FirstName } {ticket.AppUser.LastName}",
                Title = ticket.Title,
                CreateDate= ticket.CreatedDate,
                TraceNumber=ticket.TraceNumber,
                Detail=ticket.Detail,
                ImportanceLevel=ticket.ImportanceLevel,
                DepartmentId=ticket.DepartmentId.ToString(),
                IsLocked=ticket.IsLocked,
                AuthorizedDepartmentId=ticket.SubCategory.Category.DepartmentId.ToString(),
            };


        }

    //    c.Ticket ticket = await ticketReadRepository.Table.Include(p => p.AppUser).Include(x => x.Department).Include(x => x.SubCategory.Category).Include(x => x.SubCategory).Include(x => x.TicketFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));
    //    TicketDetailModelDto model = new TicketDetailModelDto();
    //    TicketFileModelDto fileModel = new TicketFileModelDto();
    //    model.Id = ticket.Id.ToString();
    //        model.DepartmentName = ticket.Department.Name;
    //        model.CategoryName = ticket.SubCategory.Category.Name;
    //        model.SubCategoryName = ticket.SubCategory.Name;
    //        model.UserName = ticket.AppUser.FirstName + " " + ticket.AppUser.LastName;
    //        model.Title = ticket.Title;
    //        model.CreateDate = ticket.CreatedDate;
    //        model.TraceNumber = ticket.TraceNumber;
    //        model.Detail = ticket.Detail;
    //        model.ImportanceLevel = ticket.ImportanceLevel;
    //        // c.Ticket ticketFile = await ticketReadRepository.Table.Include(p => p.TicketFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));


    //       var files = ticket.TicketFiles.Select(p => new TicketFileModelDto
    //       {
    //           Path = $"{configuration["BaseStorageUrl"]}/{p.Path}",
    //           FileName = p.FileName,
    //           Extension = Path.GetExtension(p.FileName),
    //           IsImage = IsImageHelper.FileIsImage(Path.GetExtension(p.FileName)),
    //       }).ToList();
           

    //        //foreach (var file in ticket)
    //        //{
    //        //    var fileEntry = new TicketFileModelDto
    //        //    {
    //        //        FileName = file.FileName,
    //        //        Path = $"{configuration["BaseStorageUrl"]}/{file.Path}",
    //        //        Extension = Path.GetExtension(file.FileName),
    //        //        IsImage = IsImageHelper.FileIsImage(Path.GetExtension(file.FileName)),

    //        //    };
    //        //    model.TicketFiles.Add(fileEntry);
    //        //}


    //        //model.TicketFiles = ticket.TicketFiles.Select(f => new TicketFileModelDto
    //        //{
    //        //    Path = $"{configuration["BaseStorageUrl"]}/{f.Path}",
    //        //    FileName = f.FileName,
    //        //    Extension = Path.GetExtension(f.FileName),
    //        //    IsImage = IsImageHelper.FileIsImage(Path.GetExtension(f.FileName)),
    //        //}).ToList();


    //        //return new TicketDetailModelDto
    //        //{

    //        //    Id = ticket.Id.ToString(),
    //        //    DepartmentName = ticket.Department.Name,
    //        //    CategoryName = ticket.SubCategory.Category.Name,
    //        //    SubCategoryName = ticket.SubCategory.Name,
    //        //    UserName = ticket.AppUser.FirstName + " " + ticket.AppUser.LastName,
    //        //    Title = ticket.Title,
    //        //    CreateDate = ticket.CreatedDate,
    //        //    TraceNumber = ticket.TraceNumber,
    //        //    Detail = ticket.Detail,
    //        //    ImportanceLevel = ticket.ImportanceLevel,
    //        //};
    //        return new GetByIdTicketQueryResponse
    //        {

    //            Ticket = model,
    //            TicketFiles= files
    //};
}
}
