using MediatR;

namespace Destek.Application.Features.Queries.Product.GetAllByDepartmentId
{
    public class GetAllProductByDepartmentIdQueryRequest:IRequest<GetAllProductByDepartmentIdQueryResponse>
    {
        public string DepartmentId { get; set; }
        public string Search { get; set; }
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
