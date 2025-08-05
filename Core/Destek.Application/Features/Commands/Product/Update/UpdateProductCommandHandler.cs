using Destek.Application.Repositories.ProductRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandHandler(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        public  async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            d.Product product = await productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new()
                {
                    Message = $" Hatalı bir işlem yaptınız. Ürün bulunamadı.",
                    Succeeded = false,
                };
            }
            product.WarehouseCategoryId = Guid.Parse(request.WarehouseCategoryId);
            product.BrandId=Guid.Parse(request.BrandId);
            product.Name = request.Name;
            product.Barcode = request.SerialNumber;
            product.SerialNumber = request.SerialNumber;
            product.UnitOfMeasureType = request.UnitOfMeasureType;
            product.IsActive = request.IsActive;
            product.IsDeleted = request.IsDelete;

            if (await productWriteRepository.SaveAsync() == 1)
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
