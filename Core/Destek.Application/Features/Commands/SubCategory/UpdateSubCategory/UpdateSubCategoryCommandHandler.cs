using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.SubCategory.UpdateSubCategory
{
    public class UpdateSubCategoryCommandHandler(ISubCategoryReadRepository subCategoryReadRepository,ISubCategoryWriteRepository subCategoryWriteRepository) : IRequestHandler<UpdateSubCategoryCommandRequest, UpdateSubCategoryCommandResponse>
    {
        public async Task<UpdateSubCategoryCommandResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            d.SubCategory subCategory = await subCategoryReadRepository.GetByIdAsync(request.Id);
            subCategory.Name = request.Name;
            subCategory.SequenceNumber = request.SequenceNumber;
            subCategory.IsActive = request.IsActive;
            subCategory.CategoryId = Guid.Parse(request.CategoryId);
            await subCategoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
