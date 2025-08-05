using Destek.Domain.Entities.Common;

namespace Destek.Domain.Entities
{
    public class Warehouse:BaseEntity
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public Department Department { get; set; }
        public ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }
    }
}
