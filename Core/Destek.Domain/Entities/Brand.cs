using Destek.Domain.Entities.Common;

namespace Destek.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
