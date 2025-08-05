using Destek.Domain.Entities.Common;
using Destek.Domain.Enums;

namespace Destek.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string SerialNumber { get; set; }
        public Guid WarehouseCategoryId { get; set; }
        public WarehouseCategory WarehouseCategory { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public UnitOfMeasureType UnitOfMeasureType { get; set; }
        public decimal UnitsInStock { get; set; }//Stoktaki miktar
        public ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }
    }
}
