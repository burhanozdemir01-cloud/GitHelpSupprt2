using Destek.Application.Repositories.CategoryRepo;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destek.Application.Features.Queries.ProcessingTime.GetByDepartmentId
{
    public class GetProcessingTimeByDepartmentIdQueryHandler(ICategoryReadRepository categoryReadRepository) : IRequestHandler<GetProcessingTimeByDepartmentIdQueryRequest, GetProcessingTimeByDepartmentIdQueryResponse>
    {
        public async Task<GetProcessingTimeByDepartmentIdQueryResponse> Handle(GetProcessingTimeByDepartmentIdQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = categoryReadRepository.GetAll(false).Where(x => x.DepartmentId == Guid.Parse(request.DepartmentId) && x.IsActive && !x.IsDeleted).Include(x => x.SubCategories).ThenInclude(x=>x.ProcessingTimes).OrderBy(x => x.SequenceNumber).Select(p => new
            {
                p.Id,
                p.Name,
                p.SequenceNumber,
                p.IsActive,
                p.CreatedDate,
                SubCategories = p.SubCategories.Where(x=>x.IsActive && !x.IsDeleted).OrderBy(z=>z.SequenceNumber).Select(sc => new
                {
                    sc.Id,
                    sc.Name,
                    sc.SequenceNumber,
                    sc.IsActive,
                    sc.CreatedDate,
                    ProcessingTimes = sc.ProcessingTimes.Where(x=>x.IsActive && !x.IsDeleted).Select(pt => new
                    {
                        pt.Id,
                        pt.Minute,
                        pt.IsActive
                    }).ToList()
                }).ToList()

            }).ToList(); 

            return new()
            {
                Categories = categories,


            };
        }
    }
}
