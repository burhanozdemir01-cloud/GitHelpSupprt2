using Destek.Application.DTOs.Product;

namespace Destek.Application.Features.Queries.Product.GetAllByDepartmentId
{
    public class GetAllProductByDepartmentIdQueryResponse
    {
        public int TotalCount { get; set; }

        public List<ProductModelDto> Products { get; set; }
    }
}
