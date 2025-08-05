
using Destek.Application.Exceptions;
using Destek.Application.Repositories.CategoryRepo;
using MediatR;
using Microsoft.AspNetCore.Http;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository,ICategoryReadRepository categoryReadRepository) : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
           
            d.Category category = await categoryReadRepository.GetByIdAsync(request.Id);
            category.Name = request.Name;
            category.SequenceNumber = request.SequenceNumber;
            category.IsActive = request.IsActive;
            category.DepartmentId = Guid.Parse(request.DepartmentId);
            await categoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
