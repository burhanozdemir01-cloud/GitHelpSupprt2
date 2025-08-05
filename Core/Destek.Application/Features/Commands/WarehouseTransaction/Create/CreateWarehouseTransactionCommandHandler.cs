using Destek.Application.Repositories.ProductRepo;
using Destek.Application.Repositories.TicketRepo;
using Destek.Application.Repositories.WarehouseTransactionRepo;
using Destek.Domain.Entities;
using MediatR;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Commands.WarehouseTransaction.Create
{
    public class CreateWarehouseTransactionCommandHandler(IWarehouseTransactionWriteRepository warehouseTransactionWriteRepository,IProductWriteRepository productWriteRepository,IProductReadRepository productReadRepository) : IRequestHandler<CreateWarehouseTransactionCommandRequest, CreateWarehouseTransactionCommandResponse>
    {
        public async Task<CreateWarehouseTransactionCommandResponse> Handle(CreateWarehouseTransactionCommandRequest request, CancellationToken cancellationToken)
        {
            d.Product product = await productReadRepository.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return new()
                {
                    Message = $"Hatalı bir işlem yaptınız. Ürün bulunamadı.",
                    Succeeded = false,
                };
            }
            await warehouseTransactionWriteRepository.AddAsync(new()
            {
                WarehouseId = Guid.Parse(request.WarehouseId),
                ProductId = Guid.Parse(request.ProductId),
                Quantity = request.Quantity,
                TransactionType = request.TransactionType,
                TicketId=null,
            });
            if (product != null)
            {
                product.UnitsInStock += request.Quantity;
                await warehouseTransactionWriteRepository.SaveAsync();
                return new()
                {
                    Message = $"Depoya {request.Quantity} {product.UnitOfMeasureType} Ürün Eklendi.",
                    Succeeded = true,
                };
            }
            return new()
            {
                Message = "Hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                Succeeded = false,
            };
        }
    }
}
