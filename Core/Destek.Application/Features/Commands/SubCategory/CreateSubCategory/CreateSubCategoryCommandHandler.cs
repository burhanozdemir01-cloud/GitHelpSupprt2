using Destek.Application.Repositories.CategoryRepo;
using Destek.Application.Repositories.SubCategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.SubCategory.CreateSubCategory
{
    public class CreateSubCategoryCommandHandler(ISubCategoryWriteRepository subCategoryWriteRepository) : IRequestHandler<CreateSubCategoryCommandRequest, CreateSubCategoryCommandResponse>
    {
        public async Task<CreateSubCategoryCommandResponse> Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await subCategoryWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                CategoryId = Guid.Parse(request.CategoryId),
                SequenceNumber = request.SequenceNumber
            });
            await subCategoryWriteRepository.SaveAsync();
            return new();
        }
    }
}
