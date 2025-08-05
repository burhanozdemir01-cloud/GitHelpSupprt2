using MediatR;

namespace Destek.Application.Features.Queries.Brand.GetById
{
    public class GetBrandIdQueryRequest:IRequest<GetBrandIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
