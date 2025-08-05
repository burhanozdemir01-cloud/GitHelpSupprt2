using Destek.Application.Exceptions;
using Destek.Application.Repositories.ProductRepo;
using Destek.Application.Repositories.WarehouseTransactionRepo;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.WarehouseTransaction.Cancel
{
    public class CancelWarehouseTransactionCommandHandler(IWarehouseTransactionWriteRepository warehouseTransactionWriteRepository,IWarehouseTransactionReadRepository warehouseTransactionReadRepository, IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository) : IRequestHandler<CancelWarehouseTransactionCommandRequest, CancelWarehouseTransactionCommandResponse>
    {
        public async Task<CancelWarehouseTransactionCommandResponse> Handle(CancelWarehouseTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            d.WarehouseTransaction warehouseTransaction = await warehouseTransactionReadRepository.GetByIdAsync(request.Id);
            if(warehouseTransaction == null)
            {
                throw new CommonException("Hatalı bir işlem yaptınız. Kayıt bulunamadı");
            }          
            d.Product product = await productReadRepository.GetByIdAsync(warehouseTransaction.ProductId.ToString());
            if (product == null)
            {
                throw new CommonException("Hatalı bir işlem yaptınız. Kayıt bulunamadı");
            }
            warehouseTransaction.IsActive = false;
            warehouseTransaction.IsDeleted = true;       
            if (product != null)
            {
                product.UnitsInStock += warehouseTransaction.Quantity;
                await warehouseTransactionWriteRepository.SaveAsync();
                return new();
            }

            throw new CommonException("Hata oluştu. Lütfen daha sonra tekrar deneyiniz.");
        }
    }
}
