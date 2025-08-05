using MediatR;

namespace Destek.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}
