using Destek.Application.Repositories.WarehouseRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.Warehouse.Update
{
    public class UpdateWarehouseCommandHandler(IWarehouseWriteRepository warehouseWriteRepository, IWarehouseReadRepository warehouseReadRepository) : IRequestHandler<UpdateWarehouseCommandRequest, UpdateWarehouseCommandResponse>
    {
        public async Task<UpdateWarehouseCommandResponse> Handle(UpdateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            d.Warehouse warehouse = await warehouseReadRepository.GetByIdAsync(request.Id);
            if (warehouse == null)
            {
                return new()
                {
                    Message = $"Hatalı bir işlem yaptınız. Depo bulunamadı.",
                    Succeeded = false,
                };
            }

            warehouse.Name = request.Name;
            warehouse.Location = request.Location;
            warehouse.IsActive = request.IsActive;
            warehouse.IsDeleted = request.IsDelete;
            warehouse.DepartmentId = Guid.Parse(request.DepartmentId);
           
            if (await warehouseWriteRepository.SaveAsync() == 1)
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
