using MediatR;

namespace Destek.Application.Features.Queries.Warehouse.GetById
{
    public class GetWarehouseIdQueryRequest:IRequest<GetWarehouseIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
