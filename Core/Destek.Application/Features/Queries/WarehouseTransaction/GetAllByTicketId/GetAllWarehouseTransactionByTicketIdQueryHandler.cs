using Destek.Application.DTOs.WarehouseTransaction;
using Destek.Application.Repositories.WarehouseTransactionRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByTicketId
{
    public class GetAllWarehouseTransactionByTicketIdQueryHandler(IWarehouseTransactionReadRepository warehouseTransactionReadRepository) : IRequestHandler<GetAllWarehouseTransactionByTicketIdQueryRequest, GetAllWarehouseTransactionByTicketIdQueryResponse>
    {
        public async Task<GetAllWarehouseTransactionByTicketIdQueryResponse> Handle(GetAllWarehouseTransactionByTicketIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseTransactionReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.IsActive && x.TicketId == Guid.Parse(request.TicketId)).Include(x => x.Warehouse).Include(x => x.Product).Include(x => x.Product.Brand);

            IQueryable<d.WarehouseTransaction> queryWarehouseTransaction = null;
            int totalCount = 0;
            if (!string.IsNullOrEmpty(request.Search))
            {

                queryWarehouseTransaction = query.Where(x => (x.Product.Name.Contains(request.Search) || x.Product.Brand.Name.Contains(request.Search) || x.Product.SerialNumber.Contains(request.Search)));
                totalCount = queryWarehouseTransaction.Count();
            }
            else
            {
                queryWarehouseTransaction = query;
                totalCount = query.Count();
            }

            var datas = queryWarehouseTransaction.Skip(request.Size * request.Page).Take(request.Size).Select(data => new WarehouseTransactionModelDto
            {
                Id = data.Id.ToString(),
                TicketId=data.TicketId.ToString(),
                WarehouseName = data.Warehouse.Name,
                ProductId = data.ProductId.ToString(),
                ProductName = data.Product.Name,
                BrandName = data.Product.Brand.Name,
                SerialNumber = data.Product.SerialNumber,
                TransactionType = data.TransactionType,
                UnitOfMeasureType = data.Product.UnitOfMeasureType,
                Quantity = data.Quantity,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllWarehouseTransactionByTicketIdQueryResponse
            {
                TotalCount = totalCount,
                WarehouseTransactions = datas
            };
        }
    }
}
