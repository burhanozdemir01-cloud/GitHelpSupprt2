using Destek.Application.Repositories.ProcessingTimeRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c = Destek.Domain.Entities;
namespace Destek.Application.Features.Queries.ProcessingTime.GetSubCategoryMinute
{
    public class GetSubCategoryMinuteQueryHandler(IProcessingTimeReadRepository processingTimeReadRepository) : IRequestHandler<GetSubCategoryMinuteQueryRequest, GetSubCategoryMinuteQueryResponse>
    {
        public async Task<GetSubCategoryMinuteQueryResponse> Handle(GetSubCategoryMinuteQueryRequest request, CancellationToken cancellationToken)
        {
            c.ProcessingTime processingTime = processingTimeReadRepository.GetWhere(x => x.SubCategoryId == Guid.Parse(request.SubCategoryId) && x.IsActive && !x.IsDeleted).FirstOrDefault();
            if(processingTime!=null)
            {
                return new()
                {
                    Minute = processingTime.Minute,
                };
            }


            return new()
            {
                Minute = 0,
            };

        }
    }
}
