using Destek.Application.Exceptions;
using Destek.Application.Repositories.CategoryRepo;
using ET.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Destek.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository) : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

          
            await categoryWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                DepartmentId = Guid.Parse(request.DepartmentId),
                SequenceNumber = request.SequenceNumber
              
            });
            await categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
