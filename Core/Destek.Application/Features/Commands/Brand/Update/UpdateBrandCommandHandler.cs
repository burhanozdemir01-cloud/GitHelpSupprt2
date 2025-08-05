using Destek.Application.Repositories.BrandRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Brand.Update
{
    public class UpdateBrandCommandHandler (IBrandWriteRepository brandWriteRepository,IBrandReadRepository brandReadRepository): IRequestHandler<UpdateBrandCommandRequest, UpdateBrandCommandResponse>
    {
        public async Task<UpdateBrandCommandResponse> Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
        {
            d.Brand brand = await brandReadRepository.GetByIdAsync(request.Id);
            if (brand == null)
            {
                return new()
                {
                    Message = $" Hatalı bir işlem yaptınız. Marka bulunamadı.",
                    Succeeded = false,
                };
            }

            brand.Name = request.Name;
            brand.IsActive = request.IsActive;
            brand.IsDeleted = request.IsDelete;
            brand.DepartmentId = Guid.Parse(request.DepartmentId);

            if (await brandWriteRepository.SaveAsync() == 1)
                return new()
                {
                    Message = $"{request.Name} Başarılı bir şekilde güncellendi.",
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
