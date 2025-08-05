using Destek.Domain.Entities.Common;

namespace Destek.Domain.Entities
{
    public class WarehouseCategory : BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
