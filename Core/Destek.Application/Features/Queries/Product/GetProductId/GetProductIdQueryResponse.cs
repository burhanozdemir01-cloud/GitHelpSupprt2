using Destek.Domain.Enums;

namespace Destek.Application.Features.Queries.Product.GetProductId
{
    public class GetProductIdQueryResponse
    {
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string WarehouseCategoryId { get; set; }
        public string BrandId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string SerialNumber { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public decimal UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
