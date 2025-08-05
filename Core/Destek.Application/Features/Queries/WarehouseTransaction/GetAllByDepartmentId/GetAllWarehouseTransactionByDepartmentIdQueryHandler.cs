using Destek.Application.DTOs.WarehouseTransaction;
using Destek.Application.Helpers;
using Destek.Application.Repositories.WarehouseTransactionRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using d = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.WarehouseTransaction.GetAllByDepartmentId
{
    public class GetAllWarehouseTransactionByDepartmentIdQueryHandler(IWarehouseTransactionReadRepository warehouseTransactionReadRepository) : IRequestHandler<GetAllWarehouseTransactionByDepartmentIdQueryRequest, GetAllWarehouseTransactionByDepartmentIdQueryResponse>
    {
        public async Task<GetAllWarehouseTransactionByDepartmentIdQueryResponse> Handle(GetAllWarehouseTransactionByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = warehouseTransactionReadRepository.GetAll(false).Where(x => !x.IsDeleted && x.Warehouse.DepartmentId == Guid.Parse(request.DepartmentId)).Include(x => x.Warehouse).Include(x => x.Product).Include(x => x.Product.Brand);

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

            var datas = queryWarehouseTransaction.Skip(request.Size * request.Page).Take(request.Size).OrderByDescending(c=>c.CreatedDate).Select(data => new WarehouseTransactionModelDto
            {
                Id = data.Id.ToString(),
                WarehouseName = $"{data.Warehouse.Name} - {data.Warehouse.Location}",
                ProductId = data.ProductId.ToString(),
                ProductName =$"{data.Product.Name} - {data.Product.UnitsInStock} / {UnitOfMeasureHelper.GetDisplayName(data.Product.UnitOfMeasureType)}",
                BrandName = data.Product.Brand.Name,
                SerialNumber = data.Product.SerialNumber,
                TransactionType = data.TransactionType,
                Quantity = data.Quantity,
                UnitOfMeasureType=data.Product.UnitOfMeasureType,
                IsActive = data.IsActive,
                IsDelete = data.IsDeleted,
                CreateDate = data.CreatedDate,

            }).ToList();

            return new GetAllWarehouseTransactionByDepartmentIdQueryResponse
            {
                TotalCount = totalCount,
                WarehouseTransactions = datas
            };
        }
    }
}
