using MediatR;

namespace Destek.Application.Features.Queries.WarehouseCategory.GetById
{
    public class GetWarehouseCategoryIdQueryRequest:IRequest<GetWarehouseCategoryIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
