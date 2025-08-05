using Destek.Domain.Enums;

namespace Destek.Application.DTOs.Product
{
    public class ProductModelDto
    {
        public string Id { get; set; }
        public string WarehouseCategoryName { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string SerialNumber { get; set; }
        
        public DateTime? CreateDate { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public decimal UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
