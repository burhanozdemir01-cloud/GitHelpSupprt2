using Destek.Domain.Entities.Common;

namespace Destek.Domain.Entities
{
    public class ProcessingTime:BaseEntity
    {
        public Guid SubCategoryId { get; set; }    
        public int Minute { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
