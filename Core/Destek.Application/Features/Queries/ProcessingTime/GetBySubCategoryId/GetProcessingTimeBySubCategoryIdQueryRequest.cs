using MediatR;

namespace Destek.Application.Features.Queries.ProcessingTime.GetBySubCategoryId
{
    public class GetProcessingTimeBySubCategoryIdQueryRequest:IRequest<GetProcessingTimeBySubCategoryIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
