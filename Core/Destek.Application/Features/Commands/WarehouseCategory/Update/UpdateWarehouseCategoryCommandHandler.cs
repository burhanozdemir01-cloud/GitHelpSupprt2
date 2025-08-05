using Destek.Application.Repositories.WarehouseCategoryRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.WarehouseCategory.Update
{
    public class UpdateWarehouseCategoryCommandHandler(IWarehouseCategoryWriteRepository warehouseCategoryWriteRepository,IWarehouseCategoryReadRepository warehouseCategoryReadRepository) : IRequestHandler<UpdateWarehouseCategoryCommandRequest, UpdateWarehouseCategoryCommandResponse>
    {
        public async Task<UpdateWarehouseCategoryCommandResponse> Handle(UpdateWarehouseCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            d.WarehouseCategory warehouseCategory = await warehouseCategoryReadRepository.GetByIdAsync(request.Id);
            if (warehouseCategory == null)
            {
                return new()
                {
                    Message = $" Hatalı bir işlem yaptınız. Kategori bulunamadı.",
                    Succeeded = false,
                };
            }

            warehouseCategory.Name = request.Name;
            warehouseCategory.IsActive = request.IsActive;
            warehouseCategory.IsDeleted = request.IsDelete;
            warehouseCategory.DepartmentId = Guid.Parse(request.DepartmentId);

            if (await warehouseCategoryWriteRepository.SaveAsync() == 1)
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
