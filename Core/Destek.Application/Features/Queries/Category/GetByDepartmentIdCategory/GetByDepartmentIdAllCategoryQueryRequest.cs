using MediatR;

namespace Destek.Application.Features.Queries.Category.GetByDepartmentIdCategory
{
    public class GetByDepartmentIdAllCategoryQueryRequest:IRequest<GetByDepartmentIdAllCategoryQueryResponse>
    {

        public string DepartmentId { get; set; }
    }
}
