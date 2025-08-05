using Destek.Application.Repositories.ProcessingTimeRepo;
using MediatR;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.ProcessingTime.GetBySubCategoryId
{
    public class GetProcessingTimeBySubCategoryIdQueryHandler(IProcessingTimeReadRepository processingTimeReadRepository) : IRequestHandler<GetProcessingTimeBySubCategoryIdQueryRequest, GetProcessingTimeBySubCategoryIdQueryResponse>
    {
        public async Task<GetProcessingTimeBySubCategoryIdQueryResponse> Handle(GetProcessingTimeBySubCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            c.ProcessingTime processingTime = processingTimeReadRepository.GetWhere(x => x.SubCategoryId == Guid.Parse(request.Id) && x.IsActive && !x.IsDeleted).FirstOrDefault();

            if(processingTime!=null)
            {
                return new()
                {
                    Id = processingTime.Id,
                    SubCategoryId = processingTime.SubCategoryId,
                    Minute = processingTime.Minute,
                };
            }

            return new()
            {
                Id = Guid.NewGuid(),
                SubCategoryId = Guid.Parse(request.Id),
                Minute = 0,
            };

        }
    }
}
