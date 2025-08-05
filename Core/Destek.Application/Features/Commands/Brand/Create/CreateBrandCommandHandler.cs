using Destek.Application.Repositories.BrandRepo;
using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Commands.Brand.Create
{
    public class CreateBrandCommandHandler(IBrandWriteRepository brandWriteRepository,IBrandReadRepository brandReadRepository) : IRequestHandler<CreateBrandCommandRequest, CreateBrandCommandResponse>
    {
        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
        {

            var isExist = brandReadRepository.GetWhere(x => x.Name == request.Name && !x.IsDeleted && x.DepartmentId == Guid.Parse(request.DepartmentId)).FirstOrDefault();
            if (isExist != null)
            {
                return new()
                {
                    Message = $"{request.Name} Markası daha önce oluşturulmuş. Aynı isimde tekrar eklenilmez.",
                    Succeeded = false,
                };
            }
            await brandWriteRepository.AddAsync(new()
            {
                Name = request.Name,
                DepartmentId = Guid.Parse(request.DepartmentId)

            });
            if (await brandWriteRepository.SaveAsync() == 1)
                return new()
                {
                    Message = $"{request.Name} Başarılı bir şekilde eklendi.",
                    Succeeded = true,
                };

            return new()
            {
                Message = "Hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                Succeeded = false,
            };
        }
    }
}
