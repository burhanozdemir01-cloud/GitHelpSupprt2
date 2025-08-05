namespace Destek.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }//başka entitylerde override ebilebilsin diye 
        public virtual string? CreatedByName { get; set; } = "Admin";
        public virtual string? ModifiedByName { get; set; } = "Admin";
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual string? Note { get; set; } = string.Empty;
    }
}
